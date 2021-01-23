    class Program
    {
        static void Main(string[] args)
        {
            var urlList = new List<string>
                              {
                                  "http://google.com",
                                  "http://yahoo.com",
                                  "http://bing.com",
                                  "http://ask.com"
                              };
            var htmlDictionary = new ConcurrentDictionary<string, string>();
            Parallel.ForEach(urlList, new ParallelOptions { MaxDegreeOfParallelism = 20 }, url => Download(url, htmlDictionary));
            foreach (var pair in htmlDictionary)
            {
                Process(pair);
            }
        }
        private static void Process(KeyValuePair<string, string> pair)
        {
            // do the html processing
        }
        private static void Download(string url, ConcurrentDictionary<string, string> htmlDictionary)
        {
            using (var webClient = new SmartWebClient())
            {
                htmlDictionary.TryAdd(url, webClient.DownloadString(url));
            }
        }
    }
    public class SmartWebClient : WebClient
    {
        private readonly int maxConcurentConnectionCount;
        public SmartWebClient(int maxConcurentConnectionCount = 20)
        {
            this.maxConcurentConnectionCount = maxConcurentConnectionCount;
        }
        protected override WebRequest GetWebRequest(Uri address)
        {
            var httpWebRequest = (HttpWebRequest)base.GetWebRequest(address);
            if (httpWebRequest == null)
            {
                return null;
            }
            if (maxConcurentConnectionCount != 0)
            {
                httpWebRequest.ServicePoint.ConnectionLimit = maxConcurentConnectionCount;
            }
            return httpWebRequest;
        }
    }
