    public class FixedQueue<T> : Queue<T>
    {
    //to sets the total number of elements that can be carried without resizing,
    //we called the base constrctor that takes the capacity
        private Random random;
        public int Size { get; private set; }
        public FixedQueue(int size, Random random)
            :base(size)                 
        {
             this.Size = size;
             this.random = random;
        }
        public new void Enqueue(T element)
        {
            base.Enqueue(element);
            lock (this)
                while (base.Count > Size)
                    base.Dequeue();  //as you said, "Oldest data falls off" :)
        }
        public T RandomAcess()
        {
            return this.ElementAt(random.Next(Count));
        }
    }
