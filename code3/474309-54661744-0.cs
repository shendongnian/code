    public static class ProcessExtensions
    {
        public static Task WaitForExitAsync(this Process process)
        {
            var tcs = new TaskCompletionSource<object>();
            process.Exited += (s, e) => tcs.TrySetResult(null);
            return process.HasExited ? Task.CompletedTask : tcs.Task;
        }        
    }
