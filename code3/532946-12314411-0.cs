    public class AsyncSynchronizationContext : SynchronizationContext
    {
        public override void Send(SendOrPostCallback d, object state)
        {
            d(state);
        }
        public override void Post(SendOrPostCallback d, object state)
        {
            ThreadPool.QueueUserWorkItem(p =>
            {
                try
                {
                    d(state);
                }
                catch (Exception ex)
                {
                    // Put your exception handling logic here.
                    Console.WriteLine(ex.Message);
                }
            });
        }
    }
