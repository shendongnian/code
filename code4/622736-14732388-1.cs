        public static async void makeRequest(int row, string url)
        {
            string result;
            Stopwatch sw = new Stopwatch(); sw.Start();
            // added here
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.AllowAutoRedirect = false;
            try
            {
                // passed in here
                using (HttpClient client = new HttpClient(httpClientHandler))
                {
