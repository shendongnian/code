    public class EnterExitExample
    {
        private Queue<object> queue;
        private bool running;
        private void ProducerThreadProc()
        {
            while (running)
            {
                object produced = ...; // Do production stuff here.
                lock (queue)
                {
                    queue.Enqueue(produced);
                    Monitor.Pulse(queue);
                }
            }
        }
        private void ConsumerThreadProc()
        {
            while (running)
            {
                lock (myLock)
                {
                    Monitor.Wait(queue);
                    object toBeConsumed = queue.Dequeue();
                    // Do consuming stuff here.
                }
            }
        }
    }
