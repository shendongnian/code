    public static class TaskExtensions
    {
        public static async Task<T> WaitOrCancel<T>(this Task<T> task, CancellationToken token, int pollPeriod = 1000)
        {
            do
            {
                token.ThrowIfCancellationRequested();
                await Task.WhenAny(task, Task.Delay(pollPeriod, token));
            } while (!task.IsCompleted);
            return await task;
        }
    }
    
