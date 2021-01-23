    class Program
    {
        private static WebClient wc = new WebClient();
        private static void Main(string[] args)
        {
            wc.DownloadProgressChanged += WcOnDownloadProgressChanged;
            wc.DownloadFileCompleted += WcOnDownloadFileCompleted;
            wc.DownloadFileAsync(new Uri(@"http://www.nattyware.com/bin/pixie.exe"), @"C:\\pixie.exe");
            Console.Read();
        }
        private static void WcOnDownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (!e.Cancelled && e.Error == null)
            {
                //async download completed successfully
            }
          
        }
        private static void WcOnDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            // handle the progres in case of async
            //e.ProgressPercentage
        }
    }
