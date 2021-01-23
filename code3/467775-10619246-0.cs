    /// <summary>
    /// A class with many-many properties
    /// </summary>
    class MyClass
    {
        public Decimal A { get; set; }
        public Decimal B { get; set; }
        public Decimal C { get; set; }
    }
    class PropertyHelper<T, TProperty>
    {
        private readonly Func<T, TProperty> selector;
        private readonly Action<T, TProperty> setter;
        public PropertyHelper(Func<T, TProperty> selector, Action<T, TProperty> setter)
        {
            this.selector = selector;
            this.setter = setter;
        }
        public Func<T, TProperty> Selector
        {
            get { return selector; }
        }
        public Action<T, TProperty> Setter
        {
            get { return setter; }
        }
    }
    class AggregateHelper<T, TProperty>
    {
        private readonly Dictionary<PropertyInfo, PropertyHelper<T, TProperty>> helpers;
        public AggregateHelper()
        {
            this.helpers = typeof(T)
                .GetProperties()
                .Where(p => p.PropertyType == typeof(TProperty))
                .ToDictionary(p => p, p => new PropertyHelper<T, TProperty>(MakeSelector(p), MakeSetter(p)));
        }
        private Func<T, TProperty> MakeSelector(PropertyInfo property)
        {
            var parameterExpr = Expression.Parameter(typeof(T));
            var lambda = (Expression<Func<T, TProperty>>)Expression.Lambda(
                Expression.Property(parameterExpr, property), parameterExpr);
            return lambda.Compile();
        }
        private Action<T, TProperty> MakeSetter(PropertyInfo property)
        {
            var instanceExpr = Expression.Parameter(typeof(T));
            var parameterValueExpr = Expression.Parameter(typeof(TProperty));
            var lambda = (Expression<Action<T, TProperty>>)Expression.Lambda(
                Expression.Call(instanceExpr, property.GetSetMethod(), parameterValueExpr),
                instanceExpr,
                parameterValueExpr);
            return lambda.Compile();
        }
        public IEnumerable<PropertyInfo> Properties
        {
            get { return helpers.Keys; }
        }
        public PropertyHelper<T, TProperty> this[PropertyInfo property]
        {
            get { return helpers[property]; }
        }
    }
