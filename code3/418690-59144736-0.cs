    using Nito.AsyncEx;
    using System;
    using System.Collections.Concurrent;
    using System.Threading.Tasks;
    public static class ThingLocker
    {
        private static readonly ConcurrentDictionary<string, AsyncLock> locks = new ConcurrentDictionary<string, AsyncLock>();
        public static async Task ExecuteLockedFunctionAsync(string key, Func<Task> func)
        {
            AsyncLock mutex = null;
            try
            {
                mutex = locks.GetOrAdd(key, new AsyncLock());
                using (await mutex.LockAsync())
                {
                    await func();
                }
            }
            finally
            {
                if (mutex != null)
                {
                    locks.TryRemove(key, out var removedValue);
                }
            }
        }
    }
