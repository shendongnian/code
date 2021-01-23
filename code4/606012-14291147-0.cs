    public Task<string> GetWebResultAsync(string url)
         {
             var tcs = new TaskCompletionSource<string>();
             var client = new WebClient();
             DownloadStringCompletedEventHandler h = null;
             h = (sender, args) =>
                     {
                         if (args.Cancelled)
                         {
                             tcs.SetCanceled();
                         }
                         else if (args.Error != null)
                         {
                             tcs.SetException(args.Error);
                         }
                         else
                         {
                             tcs.SetResult(args.Result);
                         }
                         client.DownloadStringCompleted -= h;
                     };
             client.DownloadStringCompleted += h;
             client.DownloadStringAsync(new Uri(url));
             return tcs.Task;
         }
    }
