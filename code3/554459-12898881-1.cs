    using System;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    
    class Program
    {
        static void Main(string[] args)
        {
            var urls = new[] 
            { 
                "http://www.google.com", 
                "http://www.yahoo.com" 
            };
    
            var tasks = urls.Select(url =>
            {
                var request = WebRequest.Create(url);
                return Task
                    .Factory
                    .FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, url)
                    .ContinueWith(t =>
                    {
                        if (t.IsCompleted)
                        {
                            using (var stream = t.Result.GetResponseStream())
                            using (var reader = new StreamReader(stream))
                            {
                                Console.WriteLine("-- Successfully downloaded {0} --", t.AsyncState);
                                Console.WriteLine(reader.ReadToEnd());
                            }
                        }
                        else if (t.IsFaulted)
                        {
                            Console.WriteLine("There was an error downloading {0} - {1}", t.AsyncState, t.Exception);
                        }
                    });
            }).ToArray();
    
            Task.WaitAll(tasks);
        }
    }
