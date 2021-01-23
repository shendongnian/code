    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Net;
    using System.IO;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string url = "http://stackoverflow.com";
                HttpWebRequest HttpWRequest = (HttpWebRequest)WebRequest.Create(url);
                HttpWRequest.Method = "GET";
    
                WebProxy myProxy = new WebProxy();
                
                //United States proxy, from http://www.hidemyass.com/proxy-list/
                myProxy.Address = new Uri("http://72.64.146.136:8080");
                HttpWRequest.Proxy = myProxy;
    
                HttpWebResponse HttpWResponse = (HttpWebResponse)HttpWRequest.GetResponse();
                StreamReader sr = new StreamReader(HttpWResponse.GetResponseStream(), true);
                var rawHTML = sr.ReadToEnd();
                sr.Close();
    
                Console.Out.WriteLine(rawHTML);
                Console.ReadKey();
            }
        }
    }
