    //based on https://github.com/LindaLawton/Google-Dotnet-Samples/tree/master/Google-Analytics
    
    using System;
    using System.Threading.Tasks;
    
    using System.Security.Cryptography.X509Certificates;
    using Google.Apis.Analytics.v3;
    using Google.Apis.Analytics.v3.Data;
    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Util;
    using System.Collections.Generic;
    using Google.Apis.Services;
    
    namespace GAImport
    {
    
    
        class Program
        {
            static void Main(string[] args)
            {
                string[] scopes = new string[] { AnalyticsService.Scope.AnalyticsReadonly }; 
    
                var keyFilePath = @"path\to\key.p12";    
                var serviceAccountEmail = "someuser@....gserviceaccount.com";  
    
                //loading the Key file
                var certificate = new X509Certificate2(keyFilePath, "notasecret", X509KeyStorageFlags.Exportable);
                var credential = new ServiceAccountCredential(new ServiceAccountCredential.Initializer(serviceAccountEmail)
                {
                    Scopes = scopes
                }.FromCertificate(certificate));
                var service = new AnalyticsService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Analytics API Sample",
                });
                var request = service.Data.Ga.Get("ga:1234567", "30daysAgo", "yesterday", "ga:sessions");
                request.MaxResults = 1000;
                var result = request.Execute();
                foreach (var headers in result.ColumnHeaders)
                {
                    Console.WriteLine(String.Format("{0} - {1} - {2}", headers.Name, headers.ColumnType, headers.DataType));
                }
    
                foreach (List<string> row in result.Rows)
                {
                    foreach (string col in row)
                    {
                        Console.Write(col + " "); 
                    }
                    Console.Write("\r\n");
    
                }
    
    
                Console.ReadLine();
            }
    
        }
    }
