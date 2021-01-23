    public T SafeInvocation(Func<T> myMethod)
    {
        T result = default(T);
        try
        {
            // Invoke method
            result = myMethod();
        }
        catch
        {
            // Do your common catch here
        }
        return result;
    }
