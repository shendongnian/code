    var exceptionType =
        typeof(BaseException)
            .Assembly.GetTypes()
            .Where(x => x.BaseType == typeof(BaseException))
            .Select(x => new { ExceptionType = x, Property = x.GetProperty("ErrorBitNumber", BindingFlags.Public | BindingFlags.Static) })
            .Where(x => x.Property != null)
            .FirstOrDefault(x => x.Property.GetValue(null, null) == errorBitNumber)
            .ExceptionType;
    if(exceptionType == null)
        throw new InvalidOperationException("No matching exception has been found");
    
    var exception = (BaseException)Activator.CreateInstance(exceptionType);
    throw exception;
    
