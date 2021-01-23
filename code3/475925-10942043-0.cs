    /// <summary>
    /// Type helpers
    /// </summary>
    internal static class TypeSystem
    {
        private static Type FindIEnumerable(Type seqType)
        {
            Type type;
            if (seqType == null || seqType == typeof(string) || seqType == typeof(byte[]))
            {
                return null;
            }
            else
            {
                if (!seqType.IsArray)
                {
                    if (seqType.IsGenericType)
                    {
                        Type[] genericArguments = seqType.GetGenericArguments();
                        int num = 0;
                        while (num < (int)genericArguments.Length)
                        {
                            Type type1 = genericArguments[num];
                            Type[] typeArray = new Type[1];
                            typeArray[0] = type1;
                            Type type2 = typeof(IEnumerable<>).MakeGenericType(typeArray);
                            if (!type2.IsAssignableFrom(seqType))
                            {
                                num++;
                            }
                            else
                            {
                                type = type2;
                                return type;
                            }
                        }
                    }
                    Type[] interfaces = seqType.GetInterfaces();
                    if (interfaces != null && (int)interfaces.Length > 0)
                    {
                        Type[] typeArray1 = interfaces;
                        int num1 = 0;
                        while (num1 < (int)typeArray1.Length)
                        {
                            Type type3 = typeArray1[num1];
                            Type type4 = TypeSystem.FindIEnumerable(type3);
                            if (type4 == null)
                            {
                                num1++;
                            }
                            else
                            {
                                type = type4;
                                return type;
                            }
                        }
                    }
                    if (!(seqType.BaseType != null) || !(seqType.BaseType != typeof(object)))
                    {
                        return null;
                    }
                    else
                    {
                        return TypeSystem.FindIEnumerable(seqType.BaseType);
                    }
                }
                else
                {
                    Type[] elementType = new Type[1];
                    elementType[0] = seqType.GetElementType();
                    return typeof(IEnumerable<>).MakeGenericType(elementType);
                }
            }
        }
        internal static Type GetElementType(Type seqType)
        {
            Type type = TypeSystem.FindIEnumerable(seqType);
            if (type != null)
            {
                return type.GetGenericArguments()[0];
            }
            else
            {
                return seqType;
            }
        }
    }
    /// <summary>
    /// Marks an extension as compatible for custom linq expression expansion
    /// Optionally if you can not write the extension method to fit your needs, you can provide a 
    /// expression id constant for a registered expression.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple= false, Inherited = false)]
    class ExpandableQueryMethodAttribute :
        Attribute
    {
        public ExpandableQueryMethodAttribute()
        {
        }
        public ExpandableQueryMethodAttribute(string expressionId)
        {
            _expressionId = expressionId;
        }
        private string _expressionId;
        public LambdaExpression TranslationExpression
        {
            get
            {
                return _expressionId != null ? QueryMethodTranslationExpressions.GetRegistered(_expressionId) : null;
            }
        }
    }
    /// <summary>
    /// Used to register expressions for extension method to expression substitutions
    /// </summary>
    static class QueryMethodTranslationExpressions
    {
        private static Dictionary<string, LambdaExpression> expressionList = new Dictionary<string, LambdaExpression>();
        /// <summary>
        /// Register expression
        /// </summary>
        /// <typeparam name="TFunc">type of expression delegate</typeparam>
        /// <param name="id">id constant for use with ExpandableQueryMethodAttribute</param>
        /// <param name="expr">expression</param>
        public static void RegisterExpression<TFunc>(string id, Expression<TFunc> expr)
        {
            expressionList.Add(id, expr);
        }
        public static LambdaExpression GetRegistered(string id)
        {
            //Extensions;
            return expressionList[id];
        }
    }
    static class Extensions
    {
        /// <summary>
        /// Use on object sets before using custom extension methods, except inside compiled queries
        /// </summary>
        public static IQueryable<T> AsExtendable<T>(this IQueryable<T> source)
        {
            if (source is ExtendableQuery<T>)
            {
                return (ExtendableQuery<T>)source;
            }
            return new ExtendableQueryProvider(source.Provider).CreateQuery<T>(source.Expression);
        }
    }
    /// <summary>
    /// Provides PlaceHolderQuery
    /// 
    /// No other functionality
    /// </summary>
    public class PlaceHolderQueryProvider : IQueryProvider
    {
        public PlaceHolderQueryProvider()
        {
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return new PlaceHolderQuery<TElement>(this, expression);
        }
        public IQueryable CreateQuery(Expression expression)
        {
            Type elementType = TypeSystem.GetElementType(expression.Type);
            try
            {
                return (IQueryable)Activator.CreateInstance(typeof(PlaceHolderQuery<>).MakeGenericType(elementType), new object[] { this, expression });
            }
            catch (System.Reflection.TargetInvocationException tie)
            {
                throw tie.InnerException;
            }
        }
        public TResult Execute<TResult>(Expression expression)
        {
            throw new NotImplementedException();
        }
        public object Execute(Expression expression)
        {
            throw new NotImplementedException();
        }
    }
    /// <summary>
    /// Does nothing
    /// 
    /// Acts only as a holder for expression
    /// </summary>
    public class PlaceHolderQuery<T> : IQueryable<T>, IOrderedQueryable<T>
    {
        
        private Expression _expression;
        private PlaceHolderQueryProvider _provider;
        public PlaceHolderQuery(PlaceHolderQueryProvider provider, Expression expression)
        {
            _provider = provider;
            _expression = expression;
        }
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        public Type ElementType
        {
            get
            {
                return typeof(T);
            }
        }
        public Expression Expression
        {
            get
            {
                return _expression;
            }
        }
        public IQueryProvider Provider
        {
            get
            {
                return _provider;
            }
        }
    }
    /// <summary>
    /// Walks the expression tree and invokes custom extension methods ( to expand them ) or substitutes them with custom expressions
    /// </summary>
    class ExtendableVisitor : ExpressionVisitor
    {
        class ExpandingVisitor : ExpressionVisitor
        {
            private Dictionary<ParameterExpression, Expression> _substitutionDictionary;
            public ExpandingVisitor(Dictionary<ParameterExpression, Expression> subDict)
            {
                _substitutionDictionary = subDict;
            }
            protected override Expression VisitParameter(ParameterExpression node)
            {
                if (_substitutionDictionary != null && _substitutionDictionary.ContainsKey(node))
                    return _substitutionDictionary[node];
                else
                    return base.VisitParameter(node);
            }
        }
        IQueryProvider _provider;
        internal ExtendableVisitor()
        {
            _provider = new PlaceHolderQueryProvider();
        }
        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            ExpandableQueryMethodAttribute attrib = (ExpandableQueryMethodAttribute)node.Method.GetCustomAttributes(typeof(ExpandableQueryMethodAttribute), false).FirstOrDefault();
            if (attrib != null && node.Method.IsStatic)
            {
                if (attrib.TranslationExpression != null && attrib.TranslationExpression.Parameters.Count == node.Arguments.Count)
                {
                    Dictionary<ParameterExpression, Expression> subDict = new Dictionary<ParameterExpression,Expression>();
                    for (int i = 0; i < attrib.TranslationExpression.Parameters.Count; i++)
			        {
                        subDict.Add(attrib.TranslationExpression.Parameters[i], node.Arguments[i]);
			        }
                    ExpandingVisitor expander = new ExpandingVisitor(subDict);
                    Expression exp = expander.Visit(attrib.TranslationExpression.Body);
                    return exp;
                }
                else if (typeof(IQueryable).IsAssignableFrom(node.Method.ReturnType))
                {
                    object[] args = new object[node.Arguments.Count];
                    args[0] = _provider.CreateQuery(node.Arguments[0]);
                    for (int i = 1; i < node.Arguments.Count; i++)
                    {
                        Expression arg = node.Arguments[i];
                        args[i] = (arg.NodeType == ExpressionType.Constant) ? ((ConstantExpression)arg).Value : arg;
                    }
                    Expression exp = ((IQueryable)node.Method.Invoke(null, args)).Expression;
                    return exp;
                }
            }            
            return base.VisitMethodCall(node);
        }
    }
    /// <summary>
    /// Used for query compilation
    /// 
    /// If custom extension methods are used, the existing CompileQuery functions do not work, so I had to write this.
    /// </summary>
    static class CompiledExtendableQuery
    {
        public static Func<TContext, TResult>
                   Compile<TContext, TResult>(
           Expression<Func<TContext, TResult>> expr) where TContext : ObjectContext
        {
            return System.Data.Objects.CompiledQuery.Compile(expr.Update(new ExtendableVisitor().Visit(expr.Body), expr.Parameters));
        }
        public static Func<TContext, TArg0, TResult>
                   Compile<TContext, TArg0, TResult>(
           Expression<Func<TContext, TArg0, TResult>> expr) where TContext : ObjectContext
        {
            return System.Data.Objects.CompiledQuery.Compile(expr.Update(new ExtendableVisitor().Visit(expr.Body), expr.Parameters));
        }
        public static Func<TContext, TArg0, TArg1, TResult>
                   Compile<TContext, TArg0, TArg1, TResult>
          (Expression<Func<TContext, TArg0, TArg1, TResult>> expr) where TContext : ObjectContext
        {
            return System.Data.Objects.CompiledQuery.Compile(expr.Update(new ExtendableVisitor().Visit(expr.Body), expr.Parameters));
        }
        public static Func<TContext, TArg0, TArg1, TArg2, TResult>
                   Compile<TContext, TArg0, TArg1, TArg2, TResult>(
           Expression<Func<TContext, TArg0, TArg1, TArg2, TResult>> expr) where TContext : ObjectContext
        {
            return System.Data.Objects.CompiledQuery.Compile(expr.Update(new ExtendableVisitor().Visit(expr.Body), expr.Parameters));
        }
        public static Func<TContext, TArg0, TArg1, TArg2, TArg3, TResult>
                   Compile<TContext, TArg0, TArg1, TArg2, TArg3, TResult>(
           Expression<Func<TContext, TArg0, TArg1, TArg2, TArg3, TResult>> expr) where TContext : ObjectContext
        {
            return System.Data.Objects.CompiledQuery.Compile(expr.Update(new ExtendableVisitor().Visit(expr.Body), expr.Parameters));
        }
        public static Func<TContext, TArg0, TArg1, TArg2, TArg3, TArg4, TResult>
                   Compile<TContext, TArg0, TArg1, TArg2, TArg3, TArg4, TResult>(
           Expression<Func<TContext, TArg0, TArg1, TArg2, TArg3, TArg4, TResult>> expr) where TContext : ObjectContext
        {
            return System.Data.Objects.CompiledQuery.Compile(expr.Update(new ExtendableVisitor().Visit(expr.Body), expr.Parameters));
        }
        public static Func<TContext, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TResult>
                   Compile<TContext, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(
           Expression<Func<TContext, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TResult>> expr) where TContext : ObjectContext
        {
            return System.Data.Objects.CompiledQuery.Compile(expr.Update(new ExtendableVisitor().Visit(expr.Body), expr.Parameters));
        }
        public static Func<TContext, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>
                   Compile<TContext, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(
           Expression<Func<TContext, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>> expr) where TContext : ObjectContext
        {
            return System.Data.Objects.CompiledQuery.Compile(expr.Update(new ExtendableVisitor().Visit(expr.Body), expr.Parameters));
        }
        public static Func<TContext, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>
                   Compile<TContext, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(
           Expression<Func<TContext, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>> expr) where TContext : ObjectContext
        {
            return System.Data.Objects.CompiledQuery.Compile(expr.Update(new ExtendableVisitor().Visit(expr.Body), expr.Parameters));
        }
        public static Func<TContext, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>
                   Compile<TContext, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(
           Expression<Func<TContext, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>> expr) where TContext : ObjectContext
        {
            return System.Data.Objects.CompiledQuery.Compile(expr.Update(new ExtendableVisitor().Visit(expr.Body), expr.Parameters));
        }
        public static Func<TContext, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult>
                   Compile<TContext, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult>(
           Expression<Func<TContext, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult>> expr) where TContext : ObjectContext
        {
            return System.Data.Objects.CompiledQuery.Compile(expr.Update(new ExtendableVisitor().Visit(expr.Body), expr.Parameters));
        }
        public static Func<TContext, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult>
                   Compile<TContext, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult>(
           Expression<Func<TContext, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult>> expr) where TContext : ObjectContext
        {
            return System.Data.Objects.CompiledQuery.Compile(expr.Update(new ExtendableVisitor().Visit(expr.Body), expr.Parameters));
        }
        public static Func<TContext, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TResult>
                   Compile<TContext, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TResult>(
           Expression<Func<TContext, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TResult>> expr) where TContext : ObjectContext
        {
            return System.Data.Objects.CompiledQuery.Compile(expr.Update(new ExtendableVisitor().Visit(expr.Body), expr.Parameters));
        }
        public static Func<TContext, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TResult>
                   Compile<TContext, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TResult>(
           Expression<Func<TContext, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TResult>> expr) where TContext : ObjectContext
        {
            return System.Data.Objects.CompiledQuery.Compile(expr.Update(new ExtendableVisitor().Visit(expr.Body), expr.Parameters));
        }
        public static Func<TContext, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TResult>
                   Compile<TContext, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TResult>(
           Expression<Func<TContext, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TResult>> expr) where TContext : ObjectContext
        {
            return System.Data.Objects.CompiledQuery.Compile(expr.Update(new ExtendableVisitor().Visit(expr.Body), expr.Parameters));
        }
        public static Func<TContext, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TResult>
                   Compile<TContext, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TResult>(
           Expression<Func<TContext, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TResult>> expr) where TContext : ObjectContext
        {
            return System.Data.Objects.CompiledQuery.Compile(expr.Update(new ExtendableVisitor().Visit(expr.Body), expr.Parameters));
        }
    }
    /// <summary>
    /// The query as it becomes when AsExtendable is called on it.
    /// </summary>
    class ExtendableQuery<T> : IQueryable<T>, IOrderedQueryable<T>
    {
        ExtendableQueryProvider _provider;
        Expression _expression;
        public ExtendableQuery(ExtendableQueryProvider provider, Expression expression)
        {
            _provider = provider;
            _expression = expression;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return _provider.ExecuteQuery<T>(_expression).GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public Type ElementType
        {
            get {
                return typeof(T);
            }
        }
        public Expression Expression
        {
            get {
                return _expression;    
            }
        }
        public IQueryProvider Provider
        {
            get {
                return _provider;
            }
        }
        
    }
    class ExtendableQueryProvider : IQueryProvider
    {
        IQueryProvider _underlyingQueryProvider;
        private ExtendableQueryProvider()
        {
        }
        internal ExtendableQueryProvider(IQueryProvider underlyingQueryProvider)
        {
            _underlyingQueryProvider = underlyingQueryProvider;
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return new ExtendableQuery<TElement>(this, expression);
        }
        public IQueryable CreateQuery(Expression expression)
        {
            Type elementType = TypeSystem.GetElementType(expression.Type);
            try
            {
                return (IQueryable)Activator.CreateInstance(typeof(ExtendableQuery<>).MakeGenericType(elementType), new object[] { this, expression });
            }
            catch (System.Reflection.TargetInvocationException tie)
            {
                throw tie.InnerException;
            }
        }
        internal IEnumerable<T> ExecuteQuery<T>(Expression expression)
        {
            return _underlyingQueryProvider.CreateQuery<T>(Visit(expression)).AsEnumerable();
        }
        public TResult Execute<TResult>(Expression expression)
        {
            return _underlyingQueryProvider.Execute<TResult>(Visit(expression));
        }
        public object Execute(Expression expression)
        {
            return _underlyingQueryProvider.Execute(Visit(expression));
        }
        private Expression Visit(Expression exp)
        {
            ExtendableVisitor vstr = new ExtendableVisitor();
            Expression visitedExp = vstr.Visit(exp);
            return visitedExp;
        }
    }
