    public class SomeClass : BaseClass
    {
       public void ExecuteSomethingAndWaitTillDone()
        {
            // Set up the handler to signal when we're done
            service.OnBeginSomethingCompleted += OnCompleted;
            // Invoke the asynchronous method.
            service.BeginSomething(...);
                // Now wait until the event occurs
                lock (_synchRoot)
                {
                    // This waits until Monitor.Pulse is called
                    Monitor.Wait(_synchRoot);
                }
        }
        // This handler is called when BeginSomething completes
        private void OnCompleted(object source, ...)
        {
            // Signal to the original thread that it can continue
            lock (_synchRoot)
            {
                // This lets execution continue on the original thread
                Monitor.Pulse(_synchRoot);
            }
        }
        private readonly Object _synchRoot = new Object();
    }
