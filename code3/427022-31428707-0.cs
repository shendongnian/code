    public static Task InvokeBackground(Func<Task> action)
        {
            var tcs = new TaskCompletionSource<bool>();
            var unused = ThreadPool.RunAsync(async (obj) =>
            {
                await action();
                tcs.TrySetResult(true);
            });
            return tcs.Task;
        }
