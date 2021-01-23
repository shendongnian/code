        internal sealed class SynchronizedQueue<T> {
            private readonly Object m_lock = new Object();
            private readonly Queue<T> m_queue = new Queue<T>();
            public void Enqueue(T item) {
                Monitor.Enter(m_lock);
                // After enqueuing an item, wake up any/all waiters
                m_queue.Enqueue(item);
                Monitor.PulseAll(m_lock);
                Monitor.Exit(m_lock);
            }
            public T Dequeue() {
                Monitor.Enter(m_lock);
                // Loop while the queue is empty (the condition)
                while (m_queue.Count == 0)
                    Monitor.Wait(m_lock);
                // Dequeue an item from the queue and return it for processing
                T item = m_queue.Dequeue();
                Monitor.Exit(m_lock);
                return item;
            }
        }
