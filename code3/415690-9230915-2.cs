    interface IPush<in T> { void Push(T item); }
    interface IPop<out T> { T Pop(); }
    class Stack<T> : IPush<T>, IPop<T>
    {
        private class Link
        {
            public T Item { get; private set; }
            public Link Next { get; private set; }
            public Link(T item, Link next) { this.Item = item; this.Next = next; }
        }
        
        private Link head;
        public Stack() { this.head = null; }
        
        public void Push(T item)
        {
            this.head = new Link(item, this.head);
        }
        public T Pop()
        {
            if (this.head == null) throw new InvalidOperationException();
            T value = this.head.Item;
            this.head = this.head.Next;
            return value;
        }
    }
