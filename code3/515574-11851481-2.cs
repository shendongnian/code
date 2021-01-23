    public static Task<byte[]> DownloadAsync(Uri uri, Action<double> progress)
    {
        var source = new TaskCompletionSource<byte[]>();
        Task.Factory.StartNew(
            () =>
            {
                var client = new WebClient();
                client.DownloadProgressChanged
                    += (sender, e) => progress(e.ProgressPercentage);
                client.DownloadDataCompleted
                    += (sender, e) =>
                    {
                        if (!e.Cancelled)
                        {
                            if (e.Error == null)
                            {
                                source.SetResult((byte[])e.Result);
                            }
                            else
                            {
                                source.SetException(e.Error);
                            }
                        }
                        else
                        {
                            source.SetCanceled();
                        }
                   };
            });
            
        return source.Task;
    }
