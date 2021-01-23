    class MethodResult<T>
    {
        public T Result { get; private set; }
        public Errors Errors { get; private set; }
        public MethodResult(T result) { this.Result = result; }
        public MethodResult(Errors errors) { this.Errors = errors; }
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
            return new MethodResult<Articles>(errors);
        }
    }
