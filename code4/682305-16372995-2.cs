    WebClient wc = new WebClient();
    string result = await wc.DownloadAsync("http://www.stackoverflow.com");
---
    public static partial class MyExtensions
    {
        public static Task<string> DownloadAsync(this WebClient wc, string url)
        {
            TaskCompletionSource<string> tcs = new TaskCompletionSource<string>();
            DownloadStringCompletedEventHandler completed = null;
            completed = (s, e) =>
            {
                try
                {
                    tcs.SetResult(e.Result);
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex.InnerException ?? ex);
                }
                finally
                {
                    wc.DownloadStringCompleted -= completed;
                }
            };
            wc.Headers[HttpRequestHeader.UserAgent] = "Mozilla/5.0 (Windows; U; Windows NT 6.1; de; rv:1.9.2.12) Gecko/20101026 Firefox/3.6.12";
            wc.DownloadStringCompleted += completed;
            wc.DownloadStringAsync(new Uri(url));
            return tcs.Task;
        }
    }
