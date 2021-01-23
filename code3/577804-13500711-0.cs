    public class MyQueue<T>
    {
        private Queue<T> queue;
    
        public MyQueue(int capacity)
        {
            Capacity = capacity;
            queue = new Queue<T>(capacity);
        }
    
        public int Capacity { get; private set; }
    
        public int Count { get { return queue.Count; } }
    
        public T Enqueue(T item)
        {
            queue.Enqueue(item);
            if (queue.Count > Capacity)
            {
                return queue.Dequeue();
            }
            else
            {
                //if you want this to do something else, such as return the `peek` value
                //modify as desired.
                return default(T);
            }
        }
    
        public T Peek()
        {
            return queue.Peek();
        }
    }
