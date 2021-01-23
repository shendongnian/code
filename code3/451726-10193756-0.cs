        static void Main(string[] args)
        {
            RequestByTitle("Mission Impossible");
            RequestByTitle("Mission Impossible 2");
            RequestByTitle("Mission Impossible 3");
            RequestByTitle("The Shawshank Redemption");
            Console.ReadLine();
        }
        private const String IMDBApiUrlFormatByTitle =
            "http://www.imdbapi.com/?t={0}";
        private static void RequestByTitle(String title)
        {
            String url = String.Format(IMDBApiUrlFormatByTitle, title);
            MakeRequest(url);
        }
        private static void MakeRequest(String url)
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.ServicePoint.ConnectionLimit = 10;
            req.BeginGetResponse(GetResponseCallback, req);
        }
        private static void GetResponseCallback(IAsyncResult ar)
        {
            HttpWebRequest req = ar.AsyncState as HttpWebRequest;
            String result;
            using (WebResponse resp = req.EndGetResponse(ar))
            {
                using (StreamReader reader = new StreamReader(
                    resp.GetResponseStream())
                    )
                {
                    result = reader.ReadToEnd();
                }
            }
            Console.WriteLine(result);
        }
