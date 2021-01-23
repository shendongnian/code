    class Program
    {
        static void Main(string[] args)
        {
            LinkedListNode<string> node = new LinkedListNode<string>("Hello World");
            node.NextOrFirst<string>();
            LinkedListNode<int> node2 = new LinkedListNode<int>(3);
            node2.NextOrFirst<int>();
        }
    }
    static class CircularLinkedList
    {
        public static LinkedListNode<T> NextOrFirst<T>(this LinkedListNode<T> current)
        {
            if (current.Next == null)
                return current.List.First;
            return current.Next;
        }
        public static LinkedListNode<T> PreviousOrLast<T>(this LinkedListNode<T> current)
        {
            if (current.Previous == null)
                return current.List.Last;
            return current.Previous;
        }
    }
