    public class MyBlockingQueue<T>
    {
        private Queue<T> queue = new Queue<T>();
        private AutoResetEvent signal = new AutoResetEvent(false);
        private object padLock = new object();
    
        public void Enqueue(T item)
        {
            lock (padLock)
            {
                queue.Enqueue(item);
                signal.Set();
            }
        }
    
        public T Peek()
        {
            lock (padLock)
            {
                while (queue.Count < 1)
                {
                    signal.WaitOne();
                }
    
                return queue.Peek();
            }
        }
    
        public T Dequeue()
        {
            lock (padLock)
            {
                while (queue.Count < 1)
                {
                    signal.WaitOne();
                }
    
                return queue.Dequeue();
            }
        }
    }
