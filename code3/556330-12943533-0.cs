    public class Lock
    {
        bool locked = false;
    
        private object key = new object();
        SortedDictionary<int, Queue<ManualResetEvent>> notifiers =
            new SortedDictionary<int, Queue<ManualResetEvent>>();
    
        ManualResetEvent specialNotifier = null;
    
        public void Lock()
        {
            lock (key)
            {
                if (locked)
                {
                    ManualResetEvent notifier = new ManualResetEvent(false);
    
                    int priority = getPriorityForThread();
    
                    Queue<ManualResetEvent> queue = notifiers[priority];
                    if (queue == null)
                    {
                        queue = new Queue<ManualResetEvent>();
                        notifiers[priority] = queue;
                    }
    
                    queue.Enqueue(notifier);
    
                    notifier.WaitOne();
                }
                else
                {
                    locked = true;
                }
            }
        }
    
        private static int getPriorityForThread()
        {
            return 0;
        }
    
        public void Release()
        {
            lock (key)
            {
                foreach (var queue in notifiers.Values)
                {
                    if (queue.Any())
                    {
                        var notifier = queue.Dequeue();
                        notifier.Set();
                        return;
                    }
                }
                locked = false;
            }
        }
    }
