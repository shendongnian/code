    public static class TaskEx
    {
        public static async Task<(T1, T2)> WhenAll<T1, T2>(Task<T1> task1, Task<T2> task2)
        {
            return (await task1, await task2);
        }
    }
