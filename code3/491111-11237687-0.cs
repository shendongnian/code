    class QueuePool
    {
        private readonly Task[] _queues;
        public QueuePool(int queueCount)
        { _queues = new Task[queueCount]; }
        public void Enqueue(int queueIndex, Action action)
        {
            lock (_queues)
            {
               var parent = _queue[queueIndex];
               if (parent == null)
                   _queues[queueIndex] = Task.Factory.StartNew(action);
               else
                   _queues[queueIndex] = parent.ContinueWith(_ => action());
            }
        }
    }
