    public class ArrayEnumIndex<TEnum, TElement> : IEnumerable<TElement> 
        where TEnum : struct, IConvertible
    {
        public int Length { get; }
        public TElement this[TEnum index] { get; set; }
        public void Clear();
        public void CopyTo(Array array, int index);
        public bool Exists(Predicate<TElement> match);
        public TEnum? FindIndex(Predicate<TElement> match);
        public IEnumerable<TEnum> FindAllIndices(Predicate<TElement> match);
        public IEnumerator<TElement> GetEnumerator();
    }
