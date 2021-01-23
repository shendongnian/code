    using System;
    using System.Net;
    using System.Timers;
    
    class Program
    {
        static void Main()
        {
            Timer t = new Timer(TimeSpan.FromHours(1).TotalMilliseconds);
            t.Elapsed += (sender, e) =>
            {
                // This code will execute every hour
                using (var client = new WebClient())
                {
                    // Send an HTTP request to download the contents of the web page
                    string result = client.DownloadString("http://www.google.com");
                    // do something with the results
                    ...
                }
            };
            Console.WriteLine("press any key to stop");
            Console.ReadKey();
        }
    }
