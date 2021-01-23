    class Result<T>
    {
        public Result(T Value, Errors Errors = null)
        {
            this.Value = Value;
            this.Errors = Errors;
        }
        public T Value {get; private set;}
        public Errors Errors {get; private set;}
    }
