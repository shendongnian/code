    public static class MySqlMethods
    {
        public static bool Like(string matchExpression, string pattern)
        {
            //Your implementation
            return true;
        }
    }
    public class ChangeMethodsVisitor : ExpressionVisitor
    {
        //This method will change SqlMethods to MySqlMethods.
        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (node.Method.DeclaringType == typeof(SqlMethods))
            {
                //Getting method from MySqlMethods class.
                var method = typeof(MySqlMethods).GetMethod(node.Method.Name,
                                                             node.Method.GetParameters()
                                                                 .Select(info => info.ParameterType)
                                                                 .ToArray());
                return Expression.Call(method, node.Arguments);
            }
            return base.VisitMethodCall(node);
        }
    }
    public class MyQueryProvider : IQueryProvider
    {
        private static readonly ExpressionVisitor ExpressionVisitor = new ChangeMethodsVisitor();
        private readonly IQueryProvider _queryProvider;
        public MyQueryProvider(IQueryProvider queryProvider)
        {
            _queryProvider = queryProvider;
        }
        public IQueryable CreateQuery(Expression expression)
        {
            expression = ExpressionVisitor.Visit(expression);
            var queryable = _queryProvider.CreateQuery(expression);
            //Wrap queryable to MyQuery class.
            var makeGenericType = typeof(MyQuery<>).MakeGenericType(queryable.ElementType);
            return (IQueryable)makeGenericType.GetConstructor(new[] { typeof(IQueryable<>).MakeGenericType(queryable.ElementType) })
                                               .Invoke(new object[] { queryable });
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            expression = ExpressionVisitor.Visit(expression);
            //Wrap queryable to MyQuery class.
            var queryable = _queryProvider.CreateQuery<TElement>(expression);
            return new MyQuery<TElement>(queryable);
        }
        public object Execute(Expression expression)
        {
            expression = ExpressionVisitor.Visit(expression);
            return _queryProvider.Execute(expression);
        }
        public TResult Execute<TResult>(Expression expression)
        {
            expression = ExpressionVisitor.Visit(expression);
            return _queryProvider.Execute<TResult>(expression);
        }
    }
    public class MyQuery<T> : IOrderedQueryable<T>
    {
        private readonly IQueryable<T> _queryable;
        public MyQuery(IQueryable<T> queryable)
        {
            _queryable = queryable;
            Provider = new MyQueryProvider(_queryable.Provider);
        }
        public MyQuery(IEnumerable<T> enumerable)
            : this(enumerable.AsQueryable())
        {
        }
        public IEnumerator<T> GetEnumerator()
        {
            return _queryable.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public Expression Expression
        {
            get { return _queryable.Expression; }
        }
        public Type ElementType
        {
            get { return _queryable.ElementType; }
        }
        public IQueryProvider Provider { get; private set; }
    }
