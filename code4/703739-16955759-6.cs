    var registry = new ExceptionRegistry<int, BaseException>();
    var exceptions = 
        typeof(BaseException)
            .Assembly.GetTypes()
            .Where(x => x.BaseType == typeof(BaseException))
            .Select(x => new { ExceptionType = x, Property = x.GetProperty("ErrorBitNumber", BindingFlags.Public | BindingFlags.Static) })
            .Where(x => x.Property != null)
            .Select(x => new { Key = (int)x.Property.GetValue(null, null)
                               Factory = (Func<BaseException>)(() => Activator.CreateInstance(x.ExceptionType)) });
     foreach(var exception in exceptions)
         registry.Register(exception.Key, exception.Factory);
