        public static void Main(string[] args)
        {
            var urls = new List<string>();
            Parallel.ForEach(
                urls, 
                new ParallelOptions{MaxDegreeOfParallelism = 10},
                DownloadFile);
        }
        public static void DownloadFile(string url)
        {
            using(var sr = new StreamReader(HttpWebRequest.Create(url)                                               
               .GetResponse().GetResponseStream()))
            using(var sw = new StreamWriter(url.Substring(url.LastIndexOf('/'))))
            {
                sw.Write(sr.ReadToEnd());
            }
        }
