    public class Buffer<T> : Queue<T>
    {
        private int? maxCapacity { get; set; }
        public Buffer() { maxCapacity = null; }
        public Buffer(int capacity) { maxCapacity = capacity; }
        public void Add(T newElement)
        {
            if (this.Count == (maxCapacity ?? -1)) this.Dequeue(); // no limit if maxCapacity = null
            this.Enqueue(newElement);
        }
    }
