    class Program
    {
        private static WebClient wc = new WebClient();
        private static ManualResetEvent handle = new ManualResetEvent(true);
        private static void Main(string[] args)
        {
            wc.DownloadProgressChanged += WcOnDownloadProgressChanged;
            wc.DownloadFileCompleted += WcOnDownloadFileCompleted;
            wc.DownloadFileAsync(new Uri(@"http://www.example.com/myfile.zip"), @"C:\\myfile.zip");
            handle.WaitOne(); // wait for the async event to complete
        }
        private static void WcOnDownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (!e.Cancelled && e.Error == null)
            {
                //async download completed successfully
            }
            handle.Set(); // in both the case let the void main() know that async event had finished so that i can quit
        }
        private static void WcOnDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            // handle the progres in case of async
            //e.ProgressPercentage
        }
