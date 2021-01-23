    public interface IExpression<T>
    {
        int NumberOfPossibilities();
        IEnumerable<IEnumerable<ValueExpression<T>>> Possibilities();
        IEnumerable<ValueExpression<T>> GetNthPossibility(int n);
    }
