    using System;
    using System.IO;
    using System.Net;
    
    class Program
    {
        static void Main()
        {
            var client = new WebClient();
            client.Credentials = new NetworkCredential("username", "secret");
            client.OpenReadCompleted += (sender, args) =>
            {
                using (var reader = new StreamReader(args.Result))
                {
                    while (!reader.EndOfStream)
                    {
                        Console.WriteLine(reader.ReadLine());
                    }
                }
            };
            client.OpenReadAsync(new Uri("https://stream.twitter.com/1.1/statuses/sample.json"));
            Console.ReadLine();
        }
    }
