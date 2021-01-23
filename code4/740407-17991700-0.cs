    public Task<string> GetRssFeed(string feedUrl)
    {
           var tcs = new TaskCompletionSource<string>();
           var client = new WebClient();
           client.DownloadStringCompleted += (s, e) =>
           {
                 if (e.Error == null)
                 {
                      tcs.SetResult(e.Result);
                 }
                 else
                 {
                      tcs.SetException(e.Error);
                 }
            };
 
            client.DownloadStringAsync(new Uri(feedUrl));
            return tcs.Task;
