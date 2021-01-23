     private static Task<bool> AskUser()
        {
            var tcs = new TaskCompletionSource<bool>();
            Task.Factory.StartNew(() =>
            {
                Console.WriteLine(@"Error Occured, continue? Y\N");
                var response = Console.ReadKey();
                tcs.SetResult(response.KeyChar=='y');
            });
            return tcs.Task;
        }
        private static Task<T> RetryAsk<T>(Func<T> func, int retryCount,  TaskCompletionSource<T> tcs = null)
        {
            if (tcs == null)
                tcs = new TaskCompletionSource<T>();
            Task.Factory.StartNew(func).ContinueWith(_original =>
            {
                if (_original.IsFaulted)
                {
                    if (retryCount == 0)
                        tcs.SetException(_original.Exception.InnerExceptions);
                    else
                        AskUser().ContinueWith(t =>
                        {
                            if (t.Result)
                                RetryAsk(func, retryCount - 1, tcs);
                        });
                }
                else
                    tcs.SetResult(_original.Result);
            });
            return tcs.Task;
        } 
