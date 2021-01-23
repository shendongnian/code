    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Net;
    using System.IO;
    
    namespace CRM_REST_FromConsoleApplication
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                var url = new Uri(@"https://MyServer/MyOrganiation/xrmservices/2011/organizationdata.svc/AccountSet?$select=Name&$top=10");
    
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
    
                //TODO: Set Credentials Here            
                request.Credentials = new NetworkCredential("USERNAME GOES HERE", "PASSWORD GOES HERE", "myDomain");
                
    
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
    
                    Console.WriteLine(reader.ReadToEnd());
                }
    
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    } 
       
