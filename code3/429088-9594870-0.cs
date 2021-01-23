    public class GenericNumericComparer<T> : IComparer<T>
    {
        private static readonly NumericComparer _innerComparer = new NumericComparer();
    
        public int Compare(T x, T y)
        {
            return _innerComparer.Compare(x, y); // I'm guessing this is how NumericComparer works
        }
    }
