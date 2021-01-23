    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace WcfClient
    {
    
        class Program
        {
            static void Main(string[] args) {
    
                AService.AsmbServiceSoapClient client = new AService.AsmbServiceSoapClient();
    
                int clientId = client.Login("http://www.someurl.com", "test", 1);
    
                Console.WriteLine(clientId);
                Console.ReadLine();
            }
        }
    }
