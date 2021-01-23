    public IEnumerable<Expression<Func<TModel, dynamic>>> CreateME<TModel>()
        {
            var stack = new Stack<StackItem>();
            var type = typeof(TModel);
            var parameterExpression = Expression.Parameter(type, "x");
            stack.Push(new StackItem(typeof(TModel), parameterExpression));
            while (stack.Count > 0)
            {
                var currentItem = stack.Pop();
                var properties = currentItem.PropertyType.GetProperties();
                foreach (var property in properties)
                {
                    if (IsComplexProperty(property))
                        stack.Push(new StackItem(property.PropertyType, Expression.PropertyOrField(currentItem.AccessChainExpression, property.Name)));
                    else
                    {
                        yield return GetSimplePropertyExpression<TModel>(parameterExpression, currentItem.AccessChainExpression, property.Name);
                    }
                }
            }
        }
        private static Expression<Func<TModel, dynamic>> GetSimplePropertyExpression<TModel>(ParameterExpression lhs, Expression accessChain, string propertyName)
        {
            var memberAccess = Expression.Convert(Expression.PropertyOrField(accessChain, propertyName), typeof(object));
            return Expression.Lambda<Func<TModel, dynamic>>(memberAccess, lhs);
        }
        private static bool IsComplexProperty(PropertyInfo p)
        {
            return !typeof (ICollection).IsAssignableFrom(p.PropertyType) && p.PropertyType.Namespace != "System";
        }
        class StackItem
        {
            public StackItem(Type propertyType, Expression accessChainExpression)
            {
                PropertyType = propertyType;
                AccessChainExpression = accessChainExpression;
            }
            public Type PropertyType { get; private set; }
            public Expression AccessChainExpression { get; private set; }
        }
