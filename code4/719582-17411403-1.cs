    public class ValueExpression<T> : IExpression<T>
    {
        public T Value { get; set; }
        public ValueExpression(T value)
        {
            Value = value;
        }
        public int NumberOfPossibilities()
        {
            return 1;
        }
        public IEnumerable<IEnumerable<ValueExpression<T>>> Possibilities()
        {
            return new[] { new[] { this } };
        }
        public IEnumerable<ValueExpression<T>> GetNthPossibility(int n)
        {
            return new[] { this };
        }
    }
