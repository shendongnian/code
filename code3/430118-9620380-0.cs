    namespace RestSharpThingy
    {
        using System;
        using System.Collections.Generic;
        using System.IO;
        using System.Linq;
        using System.Net;
        using System.Reflection;
    
        using RestSharp;
    
        public static class Program
        {
            public static void Main()
            {
                Uri baseUrl = new Uri("https://httpbin.org/");
                IRestClient client = new RestClient(baseUrl);
                IRestRequest request = new RestRequest("get", Method.GET) { Credentials = new NetworkCredential("testUser", "P455w0rd") };
    
                request.AddHeader("Authorization", "Bearer qaPmk9Vw8o7r7UOiX-3b-8Z_6r3w0Iu2pecwJ3x7CngjPp2fN3c61Q_5VU3y0rc-vPpkTKuaOI2eRs3bMyA5ucKKzY1thMFoM0wjnReEYeMGyq3JfZ-OIko1if3NmIj79ZSpNotLL2734ts2jGBjw8-uUgKet7jQAaq-qf5aIDwzUo0bnGosEj_UkFxiJKXPPlF2L4iNJSlBqRYrhw08RK1SzB4tf18Airb80WVy1Kewx2NGq5zCC-SCzvJW-mlOtjIDBAQ5intqaRkwRaSyjJ_MagxJF_CLc4BNUYC3hC2ejQDoTE6HYMWMcg0mbyWghMFpOw3gqyfAGjr6LPJcIly__aJ5__iyt-BTkOnMpDAZLTjzx4qDHMPWeND-TlzKWXjVb5yMv5Q6Jg6UmETWbuxyTdvGTJFzanUg1HWzPr7gSs6GLEv9VDTMiC8a5sNcGyLcHBIJo8mErrZrIssHvbT8ZUPWtyJaujKvdgazqsrad9CO3iRsZWQJ3lpvdQwucCsyjoRVoj_mXYhz3JK3wfOjLff16Gy1NLbj4gmOhBBRb8rJnUXnP7rBHs00FAk59BIpKLIPIyMgYBApDCut8V55AgXtGs4MgFFiJKbuaKxq8cdMYEVBTzDJ-S1IR5d6eiTGusD5aFlUkAs9NV_nFw");
                request.AddParameter("clientId", 123);
    
                IRestResponse<RootObject> response = client.Execute<RootObject>(request);
    
                if (response.IsSuccessful)
                {
                    response.Data.Write();
                }
                else
                {
                    Console.WriteLine(response.ErrorMessage);
                }
    
                Console.WriteLine();
    
                string path = Assembly.GetExecutingAssembly().Location;
                string name = Path.GetFileName(path);
    
                request = new RestRequest("post", Method.POST);
                request.AddFile(name, File.ReadAllBytes(path), name, "application/octet-stream");
                response = client.Execute<RootObject>(request);
                if (response.IsSuccessful)
                {
                    response.Data.Write();
                }
                else
                {
                    Console.WriteLine(response.ErrorMessage);
                }
    
                Console.ReadLine();
            }
    
            private static void Write(this RootObject rootObject)
            {
                Console.WriteLine("clientId: " + rootObject.args.clientId);
                Console.WriteLine("Accept: " + rootObject.headers.Accept);
                Console.WriteLine("AcceptEncoding: " + rootObject.headers.AcceptEncoding);
                Console.WriteLine("AcceptLanguage: " + rootObject.headers.AcceptLanguage);
                Console.WriteLine("Authorization: " + rootObject.headers.Authorization);
                Console.WriteLine("Connection: " + rootObject.headers.Connection);
                Console.WriteLine("Dnt: " + rootObject.headers.Dnt);
                Console.WriteLine("Host: " + rootObject.headers.Host);
                Console.WriteLine("Origin: " + rootObject.headers.Origin);
                Console.WriteLine("Referer: " + rootObject.headers.Referer);
                Console.WriteLine("UserAgent: " + rootObject.headers.UserAgent);
                Console.WriteLine("origin: " + rootObject.origin);
                Console.WriteLine("url: " + rootObject.url);
                Console.WriteLine("data: " + rootObject.data);
                Console.WriteLine("files: ");
                foreach (KeyValuePair<string, string> kvp in rootObject.files ?? Enumerable.Empty<KeyValuePair<string, string>>())
                {
                    Console.WriteLine("\t" + kvp.Key + ": " + kvp.Value);
                }
            }
        }
    
        public class Args
        {
            public string clientId { get; set; }
        }
    
        public class Headers
        {
            public string Accept { get; set; }
    
            public string AcceptEncoding { get; set; }
    
            public string AcceptLanguage { get; set; }
    
            public string Authorization { get; set; }
    
            public string Connection { get; set; }
    
            public string Dnt { get; set; }
    
            public string Host { get; set; }
    
            public string Origin { get; set; }
    
            public string Referer { get; set; }
    
            public string UserAgent { get; set; }
        }
    
        public class RootObject
        {
            public Args args { get; set; }
    
            public Headers headers { get; set; }
    
            public string origin { get; set; }
    
            public string url { get; set; }
    
            public string data { get; set; }
    
            public Dictionary<string, string> files { get; set; }
        }
    }
