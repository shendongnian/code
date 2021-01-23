    public static class SOExtensions
    {
        public static Task<T> WithTimeout<T>(this Task<T> task, int duration)
        {
            return Task.Factory.StartNew(() =>
            {
                bool b = task.Wait(duration);
                if (b) return task.Result;
                return default(T);
            });
        }
    }
