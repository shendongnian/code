        public static void Main(string[] args)
        {
            var urls = new List<string>();
            Parallel.ForEach(urls, new ParallelOptions{MaxDegreeOfParallelism = 10},DownloadFile);
        }
        public static void DownloadFile(string url)
        {
            browser.Navigate(url);
            while (browser.ReadyState != WebBrowserReadyState.Complete) Application.DoEvents();
            using(StreamReader sr = new StreamReader(browser.DocumentStream));
            {
                using(StreamWriter sw = new StreamWriter(), url.Substring(url.LastIndexOf('/')))
                {
                    sw.Write(sr.ReadToEnd());
                }
            };
        }
