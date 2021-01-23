    public class DelayQueue<T>
    {
        private PriorityQueue<DateTime, T> queue = new PriorityQueue<DateTime, T>();
        public void Enqueue(T item, int delay)
        {
            queue.Push(DateTime.Now.AddMilliseconds(delay), item);
        }
    
        public T Dequeue()
        {
            if (queue.Peek().Item1 > DateTime.Now)
                return queue.Pop();
            else
                return default(T);
        }
    }
