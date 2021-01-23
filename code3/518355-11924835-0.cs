    public class EventWaiter
    {
        public enum Mode
        {
            Wait,
            Detach
        }
        public static Func<Mode, TEventArgs> Create<TDelegate, TEventArgs>(
            Func<Action<object, TEventArgs>, TDelegate> converter,
            Action<TDelegate> addHandler,
            Action<TDelegate> removeHandler
            )
        {
            AutoResetEvent semaphore = new AutoResetEvent(false);
            TEventArgs args = default(TEventArgs);
            TDelegate handler = converter((s, e) => {  args = e; semaphore.Set(); });
            
            addHandler(handler);
            return mode =>
            {
                if (mode == Mode.Wait)
                {
                    semaphore.WaitOne(); 
                    return args;
                }
                else
                {
                    removeHandler(handler);
                    return default(TEventArgs);
                }
            };
        }
