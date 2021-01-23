    public class SinglyLinkedList<T>
    {
        public SinglyLinkedList()
        {
        }
    
        private SinglyNode _head = null;
    
        private class SinglyNode
        {
            public T Data { get; set; }
            public SinglyNode Next { get; set; }
        }
    
        private class Enumerator
        {
            public Enumerator(SinglyLinkedList<T> list)
            {
                _list = list; //#1
                _head = list._head; //#2
            }
    
            private SinglyLinkedList<T> _list = null;
            private SinglyNode _head = null;
        }
    }
