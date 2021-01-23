    public class ReadOnlyNode<T>
    {
        public readonly T Value;
        public readonly ReadOnlyNode<T> Next;
        public readonly ReadOnlyNode<T> Prev;
        private ReadOnlyNode(IEnumerator<T> elements, ReadOnlyNode<T> prev, bool first)
        {
            var empty = false;
            if (first) 
               empty = elements.MoveNext();
            
            if(!empty)
            {
               Value = elements.Current;
               Next = elements.MoveNext() ? new ReadOnlyNode<T>(elements, this, false) : null;
               Prev = prev;
            }
        }
        public ReadOnlyNode(IEnumerable<T> elements)
            : this(elements.GetEnumerator(), null, true)
        {
        }
    }
