    public static T? ParseOrNull<T>(this string str)
        where T: struct, IConvertible
    {
        // find the TryParse method.
        var parseMethod = typeof(T).GetMethod("TryParse", 
                                        // We want the public static one
                                        BindingFlags.Public | BindingFlags.Static,
                                        Type.DefaultBinder,
                                        // where the arguments are (string, out T)
                                        new[] { typeof(string), typeof(T).MakeByRefType() },
                                        null);
        if (parseMethod == null)
            return null; // we couldn't find the function
        // create the parameter list for the function call
        var args = new object[] { str, default(T) };
        // and then call the function.
        if ( (bool)parseMethod.Invoke(null, args))
            return (T?)args[1]; // if it returned true
        // if it returned false
        return null;
    }
