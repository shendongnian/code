    public class MyWebClient : WebClient
    {
        //time in milliseconds
        private int timeout;
        public int Timeout
        {
            get
            {
                return timeout;
            }
            set
            {
                timeout = value;
            }
        }
        public MyWebClient(int timeout = 60000)
        {
            this.timeout = timeout;
            this.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(MyWebClient_DownloadFileCompleted);
        }
        EventWaitHandle asyncWait = new ManualResetEvent(false);
        public void DownloadFileWithEvents(string url, string outputPath)
        {
            asyncWait.Reset();
            Uri uri = new Uri(url);
            this.DownloadFileAsync(uri, outputPath);
            asyncWait.WaitOne();
        }
        void MyWebClient_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            asyncWait.Set();
        }
        protected override WebRequest GetWebRequest(Uri address)
        {            
            var result = base.GetWebRequest(address);
            result.Timeout = this.timeout;
            return result;
        }
    }
