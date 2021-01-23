    using System;
    using System.Data.Objects;
    using System.Linq;
    using System.Linq.Expressions;
    static class EntityFunctionsFake
    {
        public static DateTime? AddDays(DateTime? original, int? numberOfDays)
        {
            if (!original.HasValue || !numberOfDays.HasValue)
            {
                return null;
            }
            return original.Value.AddDays(numberOfDays.Value);
        }
    }
    public class EntityFunctionsFakerVisitor : ExpressionVisitor
    {
        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (node.Method.DeclaringType == typeof(EntityFunctions))
            {
                var visitedArguments = Visit(node.Arguments).ToArray();
                return Expression.Call(typeof(EntityFunctionsFake), node.Method.Name, node.Method.GetGenericArguments(), visitedArguments);
            }
            return base.VisitMethodCall(node);
        }
    }
    class VisitedQueryProvider<TVisitor> : IQueryProvider
        where TVisitor : ExpressionVisitor, new()
    {
        private readonly IQueryProvider _underlyingQueryProvider;
        public VisitedQueryProvider(IQueryProvider underlyingQueryProvider)
        {
            if (underlyingQueryProvider == null) throw new ArgumentNullException();
            _underlyingQueryProvider = underlyingQueryProvider;
        }
        private static Expression Visit(Expression expression)
        {
            return new TVisitor().Visit(expression);
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return new VisitedQueryable<TElement, TVisitor>(_underlyingQueryProvider.CreateQuery<TElement>(Visit(expression)));
        }
        public IQueryable CreateQuery(Expression expression)
        {
            var sourceQueryable = _underlyingQueryProvider.CreateQuery(Visit(expression));
            var visitedQueryableType = typeof(VisitedQueryable<,>).MakeGenericType(
                sourceQueryable.ElementType,
                typeof(TVisitor)
                );
            return (IQueryable)Activator.CreateInstance(visitedQueryableType, sourceQueryable);
        }
        public TResult Execute<TResult>(Expression expression)
        {
            return _underlyingQueryProvider.Execute<TResult>(Visit(expression));
        }
        public object Execute(Expression expression)
        {
            return _underlyingQueryProvider.Execute(Visit(expression));
        }
    }
    public class VisitedQueryable<T, TExpressionVisitor> : IQueryable<T>
        where TExpressionVisitor : ExpressionVisitor, new()
    {
        private readonly IQueryable<T> _underlyingQuery;
        private readonly VisitedQueryProvider<TExpressionVisitor> _queryProviderWrapper;
        public VisitedQueryable(IQueryable<T> underlyingQuery)
        {
            _underlyingQuery = underlyingQuery;
            _queryProviderWrapper = new VisitedQueryProvider<TExpressionVisitor>(underlyingQuery.Provider);
        }
        public IEnumerator<T> GetEnumerator()
        {
            return _underlyingQuery.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public Expression Expression
        {
            get { return _underlyingQuery.Expression; }
        }
        public Type ElementType
        {
            get { return _underlyingQuery.ElementType; }
        }
        public IQueryProvider Provider
        {
            get { return _queryProviderWrapper; }
        }
    }
