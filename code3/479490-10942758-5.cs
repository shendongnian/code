        private class CanceledTaskCache<A>
        {
            public static Task<A> Instance;
        }
        private static Task<A> GetCanceledTask<A>()
        {
            if (CanceledTaskCache<A>.Instance == null)
            {
                var aa = new TaskCompletionSource<A>();
                aa.SetCanceled();
                CanceledTaskCache<A>.Instance = aa.Task;
            }
            return CanceledTaskCache<A>.Instance;
        }
        static Task<A> Peirce<A, B>(Func<Func<A, Task<B>>, Task<A>> a)
        {
            var aa = new TaskCompletionSource<A>();
            Func<A, Task<B>> cb = b =>
            {
                aa.SetResult(b);
                return GetCanceledTask<B>();
            };
            return Task.WhenAny(aa.Task, a(cb)).Unwrap();
        }
