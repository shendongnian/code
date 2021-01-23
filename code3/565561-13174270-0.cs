    public static class Extensions
    {
        public static Task<string> DownloadStringTask(this WebClient webClient, Uri uri)
        {
            var tcs = new TaskCompletionSource<string>();
    
            Task.Factory.StartNew(() =>
                {
                    webClient.DownloadStringCompleted += (s, e) =>
                        {
                            if (e.Error != null)
                            {
                                tcs.SetException(e.Error);
                            }
                            else
                            {
                                tcs.SetResult(e.Result);
                            }
                        };
                    
                    webClient.DownloadStringAsync(uri);
                });
    
            return tcs.Task;
        }
    }
