    static Expression<Func<T, bool>> CreateGreaterThanExpression<T>(Expression<Func<T, decimal>> fieldExtractor, decimal value)
    {
        var xPar = Expression.Parameter(typeof(T), "x");
        var x = new ParameterRebinder(xPar);
        var getter = (MemberExpression)x.Visit(fieldExtractor.Body);
        var resultBody = Expression.GreaterThan(getter, Expression.Constant(value, typeof(decimal)));
        return Expression.Lambda<Func<T, bool>>(resultBody, xPar);
    }
    private sealed class ParameterRebinder : ExpressionVisitor
    {
        private readonly ParameterExpression _parameter;
        public ParameterRebinder(ParameterExpression parameter)
        { this._parameter = parameter; }
        protected override Expression VisitParameter(ParameterExpression p)
        { return base.VisitParameter(this._parameter); }
    }
