    public delegate bool TryParser<T>(string input, out T result);
    public static bool TryParse<T>
         (string toConvert, out T result, TryParser<T> tryParser = null)
    {
        if (toConvert == null)
            throw new ArgumentNullException("toConvert");
    
        // This whole block is only if you really need
        // it to work in a truly dynamic way. You can additionally consider 
        // memoizing the default try-parser on a per-type basis.
        if (tryParser == null)
        {
            var method = typeof(T).GetMethod
                     ("TryParse", new[] { typeof(string), typeof(T).MakeByRefType() });
    
            if (method == null)
                throw new InvalidOperationException("Type does not have a built in try-parser.");
    
            tryParser = (TryParser<T>)Delegate.CreateDelegate
                (typeof(TryParser<T>), method);
        }
    
        return tryParser(toConvert, out result);
    }
