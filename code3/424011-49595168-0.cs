     public class ProgressEventArgsEx
    {
        public int Percentage { get; set; }
        public string Text { get; set; }
    }
    public async static Task<string> DownloadStraingAsyncronous(string url, IProgress<ProgressEventArgsEx> progress)
    {
        WebClient c = new WebClient();
        byte[] buffer = new byte[1024];
        var bytes = 0;
        var all = String.Empty;
        using (var stream = await c.OpenReadTaskAsync(url))
        {
            int total = -1;
            Int32.TryParse(c.ResponseHeaders[HttpRequestHeader.ContentLength], out total);
            for (; ; )
            {
                int len = await stream.ReadAsync(buffer, 0, buffer.Length);
                if (len == 0)
                    break;
                string text = c.Encoding.GetString(buffer, 0, len);
                bytes += len;
                all += text;
                if (progress != null)
                {
                    var args = new ProgressEventArgsEx();
                    args.Percentage = (total <= 0 ? 0 : (100 * total) / total);
                    progress.Report(args);
                }
            }
        }
        return all;
    }
    // Sample
    private async void Bttn_Click(object sender, RoutedEventArgs e)
    {
        //construct Progress<T>, passing ReportProgress as the Action<T> 
        var progressIndicator = new Progress<ProgressEventArgsEx>(ReportProgress);
        await TaskLoader.DownloadStraingAsyncronous(tbx.Text, progressIndicator);
    }
    private void ReportProgress(ProgressEventArgsEx args)
    {
        this.statusText.Text = args.Text + " " + args.Percentage;
    }
