    public static object CreateRequest(Type requestType)
     {
        if(!typeof(Request).IsAssignableFrom(requestType))
            throw new ArgumentException();
        var result = Activator.CreateInstance(requestType);
        Request request = (Request)result;
       // ...
       // Assign default values, etc.
       // ...
       return result ;
    }
