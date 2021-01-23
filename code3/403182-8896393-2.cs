    public static void tween()
    {
        object wait_object = new object();
        Action OnComplete = () =>
        {
            lock (wait_object)
            {
                Monitor.Pulse(wait_object);
            }
        };
        // let's say that a background thread
        // finished really quickly here
        OnComplete();
        lock (wait_object)
        {
            // this will wait for a Pulse indefinitely
            Monitor.Wait(wait_object);
        }
    }
