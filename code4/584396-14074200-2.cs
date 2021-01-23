    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Net;
    using System.Collections;
    
    namespace ConsoleApplication4
    {
        static class Program
        {
            private static void Main()
            {
                CookieContainer cookies = new CookieContainer();
                cookies.Add(new Cookie("name1", "value1", "/", "domain1.com"));
                cookies.Add(new Cookie("name2", "value2", "/", "domain2.com"));
    
                Hashtable table = (Hashtable)cookies.GetType().InvokeMember(
                    "m_domainTable",                                                      
                    BindingFlags.NonPublic |                                                                           
                    BindingFlags.GetField |                                                                     
                    BindingFlags.Instance,                                                                      
                    null,                                                                            
                    cookies,
                    new object[]{}
                );
    
                foreach (var key in table.Keys)
                {
                    Uri uri = new Uri(string.Format("http://{0}/", key));
                    foreach (Cookie cookie in cookies.GetCookies(uri))
                    {
                        Console.WriteLine("Name = {0} ; Value = {1} ; Domain = {2}",
                            cookie.Name, cookie.Value, cookie.Domain);
                    }
                }
    
                Console.Read();
            }
        }
    }
