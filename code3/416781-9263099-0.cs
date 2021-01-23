    public class LinkedList<T>
    {
        private List<LinkedListNode<T>> nodes = new List<LinkedListNode<T>>();
    }
    public class LinkedListNode<T>
    {
        public T Previous { get; set; }
        public T Next { get; set; }
        public T Item { get; set; }
    }
    public class MyClass
    {
        // Some Properties
    }
