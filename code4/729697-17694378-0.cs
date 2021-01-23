    class MethodResult<T>
    {
        public T Result { get; private set; }
        public Exception Exception { get; private set; }
        public MethodResult(T result) { this.Result = result; }
        public MethodResult(Exception exception) { this.Exception = exception; }
    }
    public MethodResult<Articles> MyMethod()
    {
        try
        {
            ... 
            return new MethodResult<Articles>(articles);
        }
        catch(Exception e)
        {
            ... 
            return new MethodResult<Articles>(e);
        }
    }
