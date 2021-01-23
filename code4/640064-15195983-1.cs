    using System;
    using System.IO;
    using System.Net.Http;
    using System.Net.Http.Headers;
    
    class Program
    {
        static void Main(string[] args)
        {
            using (var client = new HttpClient())
            using (var content = new MultipartFormDataContent())
            {
                client.BaseAddress = new Uri("http://localhost:16724/");
                var fileContent = new ByteArrayContent(File.ReadAllBytes(@"c:\work\foo.txt"));
                fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = "Foo.txt"
                };
                content.Add(fileContent);
                var result = client.PostAsync("/api/upload", content).Result;
                Console.WriteLine(result.StatusCode);
            }
        }
    }
