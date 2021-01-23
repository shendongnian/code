      TaskCompletionSource<string> tcs = 
        new TaskCompletionSource<string>();
    
      WebClient client = new WebClient();
    
      client.DownloadStringCompleted += (sender, args) => {
        if (args.Error != null) tcs.SetException(args.Error);
        else if (args.Cancelled) tcs.SetCanceled();
        else tcs.SetResult(args.Result);
      };
    
      client.DownloadStringAsync(address);
    
      tcs.Task.Wait(); // WaitForEvent
