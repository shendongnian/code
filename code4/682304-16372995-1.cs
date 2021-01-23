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
            wc.DownloadStringCompleted += completed;
            wc.DownloadStringAsync(new Uri(url));
            return tcs.Task;
        }
    }
