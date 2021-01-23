    public class OrExpression<T> : IExpression<T>
    {
        private IList<IExpression<T>> expressions;
        public OrExpression(IList<IExpression<T>> expressions)
        {
            this.expressions = expressions;
        }
        public int NumberOfPossibilities()
        {
            return expressions.Sum(expression => expression.NumberOfPossibilities());
        }
        public IEnumerable<IEnumerable<ValueExpression<T>>> Possibilities()
        {
            return Enumerable.Range(0, NumberOfPossibilities())
                .Select(n => GetNthPossibility(n));
        }
        public IEnumerable<ValueExpression<T>> GetNthPossibility(int n)
        {
            for (int i = 0; i < expressions.Count; i++)
            {
                int count = expressions[i].NumberOfPossibilities();
                if (n < count)
                    return expressions[i].GetNthPossibility(n);
                else
                    n -= count;
            }
            throw new ArgumentOutOfRangeException();
        }
    }
