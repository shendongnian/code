    public static T CreateRequest<T>()
        where T : new()
    {
        if(!typeof(Request).IsAssignableFrom(typeof(T)))
            throw new ArgumentException();
        var result = new T();
        Request request = (Request)(object)result;
       // ...
       // Assign default values, etc.
       // ...
       return result ;
    }
