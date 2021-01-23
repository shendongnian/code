    public class MyWebClient : WebClient, IDisposable
    {
        public int Timeout { get; set; }
        public int TimeUntilFirstByte { get; set; }
        public int TimeBetweenProgressChanges { get; set; }
        public long PreviousBytesReceived { get; private set; }
        public long BytesNotNotified { get; private set; }
        public string Error { get; private set; }
        public bool HasError { get { return Error != null; } }
        private bool firstByteReceived = false;
        private bool success = true;
        private bool cancelDueToError = false;
        private EventWaitHandle asyncWait = new ManualResetEvent(false);
        private Timer abortTimer = null;
        const long ONE_MB = 1024 * 1024;
        public delegate void PerMbHandler(long totalMb);
        public event PerMbHandler NotifyMegabyteIncrement;
        public MyWebClient(int timeout = 60000, int timeUntilFirstByte = 30000, int timeBetweenProgressChanges = 15000)
        {
            this.Timeout = timeout;
            this.TimeUntilFirstByte = timeUntilFirstByte;
            this.TimeBetweenProgressChanges = timeBetweenProgressChanges;
            this.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(MyWebClient_DownloadFileCompleted);
            this.DownloadProgressChanged += new DownloadProgressChangedEventHandler(MyWebClient_DownloadProgressChanged);
            abortTimer = new Timer(AbortDownload, null, TimeUntilFirstByte, System.Threading.Timeout.Infinite);
        }
        protected void OnNotifyMegabyteIncrement(long totalMb)
        {
            if (NotifyMegabyteIncrement != null) NotifyMegabyteIncrement(totalMb);
        }
        void AbortDownload(object state)
        {
            cancelDueToError = true;
            this.CancelAsync();
            success = false;
            Error = firstByteReceived ? "Download aborted due to >" + TimeBetweenProgressChanges + "ms between progress change updates." : "No data was received in " + TimeUntilFirstByte + "ms";
            asyncWait.Set();
        }
        void MyWebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            if (cancelDueToError) return;
            long additionalBytesReceived = e.BytesReceived - PreviousBytesReceived;
            PreviousBytesReceived = e.BytesReceived;
            BytesNotNotified += additionalBytesReceived;
            if (BytesNotNotified > ONE_MB)
            {
                OnNotifyMegabyteIncrement(e.BytesReceived);
                BytesNotNotified = 0;
            }
            firstByteReceived = true;
            abortTimer.Change(TimeBetweenProgressChanges, System.Threading.Timeout.Infinite);
        }
        public bool DownloadFileWithEvents(string url, string outputPath)
        {
            asyncWait.Reset();
            Uri uri = new Uri(url);
            this.DownloadFileAsync(uri, outputPath);
            asyncWait.WaitOne();
            return success;
        }
        void MyWebClient_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (cancelDueToError) return;
            asyncWait.Set();
        }
        protected override WebRequest GetWebRequest(Uri address)
        {            
            var result = base.GetWebRequest(address);
            result.Timeout = this.Timeout;
            return result;
        }
        void IDisposable.Dispose()
        {
            if (asyncWait != null) asyncWait.Dispose();
            if (abortTimer != null) abortTimer.Dispose();
            base.Dispose();
        }
    }
