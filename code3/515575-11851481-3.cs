    // var urls = new List<Uri>(...);
    // var progressBar = new ProgressBar();
    Task.Factory.StartNew(
        () =>
        {
           foreach (var uri in urls)
           {
               var task = DownloadAsync(
                   uri,
                   p =>
                       progressBar.Invoke(
                           new MethodInvoker(
                           delegate { progressBar.Value = (int)(100 * p); }))
                   );
               // Will Block!
               // data = task.Result;
           } 
        });
