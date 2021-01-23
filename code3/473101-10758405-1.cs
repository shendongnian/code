    public class ReadOnlyNode<T>
    {
        public readonly T Value;
        public readonly ReadOnlyNode<T> Next;
        public readonly ReadOnlyNode<T> Prev;
        private ReadOnlyNode(IEnumerable<T> elements, ReadOnlyNode<T> prev)
        {
            if(elements == null || !elements.Any()) 
               throw new ArgumentException(
                  "Enumerable must not be null and must have at least one element");
            Next = elements.Count() == 1 
               ? null 
               : new ReadOnlyNode<T>(elements.Skip(1), this);
            Value = elements.First();
            Prev = prev;
        }
        public ReadOnlyNode(IEnumerable<T> elements)
            : this(elements, null)
        {
        }
    }
