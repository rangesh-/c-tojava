using System;
using System.Configuration;
using java.net;


namespace CtoJava
{
    public class Program
    {
       public static void Main(string[] args)
        {
            // Create a URL instance for every jar file that you need
            java.net.URL url = new java.net.URL("file:"+ ConfigurationManager.AppSettings.Get("jarpath"));
            // Create an array of all URLS
            java.net.URL[] urls = { url };
            // Create a ClassLoader
            java.net.URLClassLoader loader = new java.net.URLClassLoader(urls);
            try
            {
                // load the Class
                java.lang.Class cl = java.lang.Class.forName(ConfigurationManager.AppSettings.Get("classname"), true, loader);
               
                object obj = cl.newInstance();
                Console.WriteLine(obj);


                string arg = "Rangesh";
                string arg1 = "test1";
                var strarg = new string[] { arg, arg1 };
                //Create a object via C# reflection
                Type types = ikvm.runtime.Util.getInstanceTypeFromClass(cl);
              var res=types.GetMethod(ConfigurationManager.AppSettings.Get("methodname")).Invoke(obj,new object[] { strarg });
                string[] test = (string[])res;
                foreach (var item in test)
                {
                    Console.WriteLine(item);
                }
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
