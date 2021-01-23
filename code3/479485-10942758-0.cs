        private class CanceledTaskCache<A>
        {
            public static Task<A> Instance;
        }
        private static Task<A> GetCanceledTask<A>()
        {
            if (CanceledTaskCache<A>.Instance == null)
            {
                var ctks = new CancellationTokenSource();
                ctks.Cancel();
                Func<A> fa = () => {
                    throw new OperationCanceledException(ctks.Token);
                };
                var ta = Task.Run(fa,ctks.Token);
                CanceledTaskCache<A>.Instance = ta;
            }
            return CanceledTaskCache<A>.Instance;
        }
        static Task<A> Peirce<A, B>(Func<Func<A, Task<B>>, Task<A>> a)
        {
            var aa = new TaskCompletionSource<A>();
            var t1 = a(b =>
            {
                aa.SetResult(b);
                return GetCanceledTask<B>(ctks.Token);
            });
            return Task.WhenAny(aa.Task, t1).Result;
        }
