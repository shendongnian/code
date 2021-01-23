        class MySqlQueryableWrapper<T> : IQueryable<T>
    {
        private readonly IQueryable<T> _queryable;
        private readonly IQueryProvider _provider;
     
        public MySqlQueryableWrapper(IQueryable<T> queryable)
        {
            _queryable = queryable;
            _provider = new MySqlQueryProviderWrapper(queryable.Provider);
        }
     
        public Type ElementType
        {
            get { return _queryable.ElementType; }
        }
     
        public Expression Expression
        {
            get { return _queryable.Expression; }
        }
     
        public IQueryProvider Provider
        {
            get { return _provider; }
        }
     
        public IEnumerator<T> GetEnumerator()
        {
            return _queryable.GetEnumerator();
        }
     
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
     
    class MySqlQueryProviderWrapper : IQueryProvider
    {
        private readonly MySqlExpressionFixer _visitor = new MySqlExpressionFixer();
        private readonly IQueryProvider _provider;
     
        public MySqlQueryProviderWrapper(IQueryProvider provider)
        {
            _provider = provider;
        }
     
        public IQueryable CreateQuery(Expression expression)
        {
            return _provider.CreateQuery(_visitor.Visit(expression));
        }
     
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return _provider.CreateQuery<TElement>(_visitor.Visit(expression));
        }
     
        public object Execute(Expression expression)
        {
            return _provider.Execute(_visitor.Visit(expression));
        }
     
        public TResult Execute<TResult>(Expression expression)
        {
            return _provider.Execute<TResult>(_visitor.Visit(expression));
        }
     
    }
     
    class MySqlExpressionFixer : ExpressionVisitor
    {    
        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (node.Method.Name == "Contains" || "StartsWith" &&
                node.Method.DeclaringType == typeof(string) &&
                node.Arguments.Count == 1)
            {
                var c = node.Arguments[0] as ConstantExpression;
                if (c != null)
                {
                    string s = c.Value as string;
                    if (s != null)
                    {
                        s = s.Replace("'", "''");
                        node = Expression.Call(node.Object, node.Method, Expression.Constant(s));
                    }
                }
            }
     
            return base.VisitMethodCall(node);
        }
    }
