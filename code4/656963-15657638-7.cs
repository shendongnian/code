    class BlockingQueue<T>
    {
        // We base our queue, on the non-thread safe 
        // .NET 2.0 queue collection
        readonly Queue<T> q = new Queue<T>();
        public void Enqueue(T item)
        {
            lock (q)
            {
                q.Enqueue(item);
                System.Threading.Monitor.Pulse(q);
            }
        }
        public T Dequeue()
        {
            lock (q)
            {
                for (; ; )
                {
                    if (q.Count > 0)
                    {
                        return q.Dequeue();
                    }
                    System.Threading.Monitor.Wait(q);
                }
            }
        }
    }
