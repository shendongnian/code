    namespace ConsoleApplication1
    {
      using System;
      using System.Net;
      using System.Net.Security;
      using System.Security.Cryptography.X509Certificates;
      class Program
      {
        static void Main()
        {
          ServicePointManager.ServerCertificateValidationCallback += ServerCertificateValidationCallback;
          var request = WebRequest.Create("https://www.google.com");
          var response = request.GetResponse();
          Console.WriteLine("Done.");
          Console.ReadLine();
        }
        private static bool ServerCertificateValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
          Console.WriteLine("Certificate expires on " + certificate.GetExpirationDateString());
          return true;
        }
      }
    }
