    public void StartEngins()
    {
        const string URL_Dollar = "URL_Dollar";
        const string URL_UpdateUsersTimeOut = "URL_UpdateUsersTimeOut";
    
    
        var urlList = new Dictionary<string, string>();
        urlList.Add(URL_Dollar, "http://bing.com");
        urlList.Add(URL_UpdateUsersTimeOut, "http://localhost:..../.......aspx");
    
    
        var htmlDictionary = new ConcurrentDictionary<string, string>();
        Parallel.ForEach(
                        urlList.Values,
                        new ParallelOptions { MaxDegreeOfParallelism = 20 },
                        url => Download(url, htmlDictionary)
                        );
        foreach (var pair in htmlDictionary)
        {
            ///Process(pair);
            MessageBox.Show(pair.Value);
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
