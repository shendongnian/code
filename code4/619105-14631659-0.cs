    public static Task Then(this Task parent, Task next)
    {
        TaskCompletionSource<object> tcs = new TaskCompletionSource<object>();
        parent.ContinueWith(pt =>
        {
            if (pt.IsFaulted)
            {
                tcs.SetException(pt.Exception.InnerException);
            }
            else
            {
                next.ContinueWith(nt =>
                {
                    if (nt.IsFaulted)
                    {
                        tcs.SetException(nt.Exception.InnerException);
                    }
                    else { tcs.SetResult(null); }
                });
                next.Start();
            }
        });
        return tcs.Task;
    }
