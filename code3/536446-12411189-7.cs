        public class FixedSizeQueue<T>
        {
        private readonly List<T> queue = new List<T>();
        private readonly object syncObj = new object();
    
        public int Size { get; private set; }
    
        public FixedSizeQueue(int size) { Size = size; }
    
        public void Enqueue(T obj)
        {
            lock (syncObj)
            {
                queue.Insert(0,obj)
                if(queue.Count > Size) 
                   queue.RemoveRange(Size, Count-Size);
            }
        }
        public T[] Dequeue()
        {
            lock (syncObj)
            {
                var result = queue.ToArray();
                queue.Clear();
                return result;
            }
        }
        }
