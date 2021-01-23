    public class AndExpression<T> : IExpression<T>
    {
        private IList<IExpression<T>> expressions;
        public AndExpression(IList<IExpression<T>> expressions)
        {
            this.expressions = expressions;
        }
        public int NumberOfPossibilities()
        {
            return expressions.Aggregate(1,
                (acc, expression) => acc * expression.NumberOfPossibilities());
        }
        IEnumerable<IEnumerable<ValueExpression<T>>> IExpression<T>.Possibilities()
        {
            return Enumerable.Range(0, NumberOfPossibilities())
                .Select(n => GetNthPossibility(n));
        }
        public IEnumerable<ValueExpression<T>> GetNthPossibility(int n)
        {
            for (int i = 0; i < expressions.Count; i++)
            {
                int count = expressions[i].NumberOfPossibilities();
                foreach (var value in expressions[i].GetNthPossibility(n % count))
                    yield return value;
                n /= count;
            }
        }
    }
