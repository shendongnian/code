    static class TaskExtensions
    {
        public static void WaitAll<T>(this Task<T>[] tasks)
        {
            foreach (var item in tasks)
            {
                item.Wait();
            }
        }
    }
