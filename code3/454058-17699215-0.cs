    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class DependencyAttribute : Attribute
    {
        // Fields
        private readonly string name;
        /// <summary>
        /// Create an instance of DependencyAttribute with no name
        /// </summary>
        public DependencyAttribute()
            : this(null)
        {
        }
        /// <summary>
        /// Create an instance of DependencyAttribute with name
        /// </summary>
        /// <param name="name"></param>
        public DependencyAttribute(string name)
        {
            this.name = name;
        }
        /// <summary>
        /// The name specified in the constructor
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
        }
    }
        public static IRegistration LegacyRegister(this IocContainer container, Type from, Type to, string name = null)
        {
            if (from.ContainsGenericParameters)
                container.Register(name, from, to);
            var reg = container.Register(name, from, Create(to));
            return reg;
        }
        public static IRegistration LegacyRegister<TFrom,TTo>(this IocContainer container, string name = null)
        {
            return container.LegacyRegister(typeof (TFrom), typeof (TTo), name);
        }
        public static System.Func<IDependencyResolver, object> Create(Type from)
        {
            var container = Expression.Parameter(typeof(IDependencyResolver), "container");
            var ctor = BuildExpression(from, container);
            var block = InitializeProperties(ctor, container);
            var func = Expression.Lambda<System.Func<IDependencyResolver, object>>(block, new[] { container});
            
            return func.Compile();
        }
        private static Expression InitializeProperties(NewExpression ctor, ParameterExpression container)
        {
            var expressionList = new List<Expression>();
            var instance = Expression.Variable(ctor.Type, "ret");
            var affect = Expression.Assign(instance, ctor);
            //expressionList.Add(instance);
            expressionList.Add(affect);
 
            var props = from p in instance.Type.GetProperties(BindingFlags.Instance|BindingFlags.NonPublic|BindingFlags.Public)
                let da = p.GetCustomAttributes(typeof (DependencyAttribute), true).Cast<DependencyAttribute>().FirstOrDefault()
                where da != null
                select new {Property = p, da.Name};
            var propsSetters = from p in props
                let resolve = p.Name == null ?
                    Expression.Call(container, "Resolve", new[] {p.Property.PropertyType})
                    : Expression.Call(container, "Resolve", new[] {p.Property.PropertyType}, Expression.Constant(p.Name, typeof (string)))
                select Expression.Call(instance, p.Property.GetSetMethod(true), resolve);
            expressionList.AddRange(propsSetters.ToList());
            expressionList.Add(instance);
            var block = Expression.Block(ctor.Type, new[] { instance }, expressionList);
            return block;
        }
        private static NewExpression BuildExpression(Type type, ParameterExpression container)
        {
            ConstructorInfo constructorInfo = GetConstructorInfo(type);
            var parameters = from p in constructorInfo.GetParameters()
                        let da = p.GetCustomAttributes(typeof(DependencyAttribute), true).Cast<DependencyAttribute>().FirstOrDefault()
                            ?? new DependencyAttribute()
                        select new { Param = p, da.Name };
            var list = parameters.Select(p => 
                Expression.Call(container, "Resolve", new [] { p.Param.ParameterType },
                    p.Name == null ? new Expression[0] : new Expression[] { Expression.Constant(p.Name, typeof(string)) }));
            return Expression.New(constructorInfo, list);
        }
        private static ConstructorInfo GetConstructorInfo(Type implType)
        {
            ConstructorInfo constructorInfo = implType.GetConstructors().OrderByDescending(c => c.GetParameters().Length).FirstOrDefault();
            if (constructorInfo == null)
                throw new ArgumentException(string.Format("The requested class {0} does not have a public constructor.", (object)implType));
            return constructorInfo;
        }
