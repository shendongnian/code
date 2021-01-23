     using System;
     using System.Collections.Generic;
     using System.Linq;
     using System.Text;
     using System.Security.Cryptography.X509Certificates;
     using System.Net;
     using System.Net.Security;
    namespace WCFSelfSignCert
    {
    class Program
    {
        static void Main(string[] args)
        {
            //You have to install your certificate as trusted certificate in your LocalMachine 
            //create your service client/ procy
            using (MyProxy.ServiceClient client = new MyProxy.ServiceClient())
            {
                //server certification respond with an error, because doesnt recognize the autority
                ServicePointManager.ServerCertificateValidationCallback += OnServerValError;
                //Assign to self sign certificate
                client.ClientCredentials.ClientCertificate.SetCertificate(StoreLocation.LocalMachine,
                StoreName.Root,
                X509FindType.FindBySubjectName,
                "MY custom subject name"); //SubjectName(CN) from  certificate
                //make a test call to ensure that service responds
                var res = client.echo("test");
                
                Console.WriteLine(res);
                Console.ReadKey();
            }
            
        }
        public static bool OnServerValError(object sender, X509Certificate certificate,    X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            //mute the error, or provide some custom validation code
            return true;
            //or more restrictive 
           
           // if (sslPolicyErrors == SslPolicyErrors.RemoteCertificateNameMismatch)
            //{
 
 
            //    return true;
           // }
           // else
            //{
 
           //    return false;
           // }
        }
       }
    }
   
