    using System;
    using System.Linq;
    using System.Net;
    using Newtonsoft.Json;
    namespace YouTube
    {
       class Program
       {
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        static void Main(string[] args)
        {
            var count = 50;
            var API_KEY = "YOUR KEY";
            var q = RandomString(3);
            var url = "https://www.googleapis.com/youtube/v3/search?key=" + API_KEY + "&maxResults="+count+"&part=snippet&type=video&q=" +q;
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(url);
                dynamic jsonObject = JsonConvert.DeserializeObject(json);
                foreach (var line in jsonObject["items"])
                {
                    Console.WriteLine(line["id"]["videoId"]);
                    /*store your id*/
                }
                Console.Read();
            }
        }
    }
    }
