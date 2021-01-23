    namespace ConsoleApplication
    {
        using System;
        using System.Linq;
        using System.Net.Http.Headers;
    
        class Program
        {
            static void Main(string[] args)
            {
                string header = "en-ca,en;q=0.8,en-us;q=0.6,de-de;q=0.4,de;q=0.2";
                var languages = header.Split(',')
                    .Select(StringWithQualityHeaderValue.Parse)
                    .OrderByDescending(s => s.Quality.GetValueOrDefault(1));
            }
        }
    }
