    using System;
    using System.Net;
    using Microsoft.TeamFoundation.Client;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                NetworkCredential netCred = new NetworkCredential(
                    "yourbasicauthusername@live.com",
                    "yourbasicauthpassword");
                BasicAuthCredential basicCred = new BasicAuthCredential(netCred);
                TfsClientCredentials tfsCred = new TfsClientCredentials(basicCred);
                tfsCred.AllowInteractive = false;
    
                TfsTeamProjectCollection tpc = new TfsTeamProjectCollection(
                    new Uri("https://YourAccountName.visualstudio.com/DefaultCollection"),
                    tfsCred);
    
                tpc.Authenticate();
    
                Console.WriteLine(tpc.InstanceId);
            }
        }
    }
