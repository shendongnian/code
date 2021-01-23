    public static Expression<TimerDelegateOut<T, TResult>> ToExpression<T, TResult>(TimerDelegateOut<T, TResult> call)
    {
        var p1 = Expression.Parameter(typeof(T).MakeByRefType(), "value");
        var methodCall = Expression.Invoke(Expression.Constant(call), p1);
        return Expression.Lambda<TimerDelegateOut<T, TResult>>(methodCall, p1);
    }
