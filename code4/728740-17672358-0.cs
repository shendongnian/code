        public static T Invoke<T>(Func<T> action)
        {
            if (Dispatcher.CheckAccess())
                return action();
            else
            {
                T result = default(T);
                ManualResetEvent reset = new ManualResetEvent(false);
                Dispatcher.BeginInvoke(() =>
                {
                    result = action();
                    reset.Set();
                });
                reset.WaitOne();
                return result;
            }
        }
