    public static Func<IDataReader, T> CreateBinder<T>() 
    {
        NewExpression dataTransferObject = Expression.New(typeof(T).GetConstructor(Type.EmptyTypes)); 
        ParameterExpression dataReader = Expression.Parameter(typeof(IDataReader), "reader");
    
        IEnumerable<MemberBinding > bindings = typeof(T).GetProperties().Select(property => {
            MethodCallExpression columnData = Expression.Call(dataReader, dataReaderIndexer, new[] { Expression.Constant(property.Name) });
            MemberBinding binding = Expression.Binding(property, Expression.Convert( columnData, property.PropertyType));
    
            return binding;
        });
        Expression init = Expression.MemberInit(dataTransferObject, bindings);
        Func<IDataReader, T> binder = Expression.Lambda<Func<IDataReader, T>>(init, new[] { dataReader }).Compile();
    
        return binder;
    }
