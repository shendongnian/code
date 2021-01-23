    public static IEnumerable<string> GetErrorMessages(this Exception e) 
    { 
        if (e == null) 
            throw new ArgumentNullException("e"); 
        yield return e.Message;
        Exception inner = e.InnerException;
        while(inner != null)
        {
            yield return inner.Message; 
            inner = inner.InnerException;
        }
    }
