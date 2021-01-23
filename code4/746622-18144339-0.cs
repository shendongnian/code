    using System;
    using System.Security.Cryptography.X509Certificates;
    namespace Encryption
       {
       class CertificateTest
          {
          static void Main()
             {
             X509Store store = new X509Store(StoreName.Root,
                StoreLocation.LocalMachine);
             store.Open(OpenFlags.ReadOnly);
             Console.WriteLine("Friendly Name\t\t\t\t\t Expiration date");
             foreach (X509Certificate2 certificate in store.Certificates)
                {
                Console.WriteLine("{0}\t{1}", certificate.FriendlyName,
                   certificate.NotAfter);
                }
             store.Close();
             }
          }
       }
