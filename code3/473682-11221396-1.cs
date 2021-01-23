    public class Exceptional<T>
    {
        public bool HasException { get; private set; }
        public Exception Exception { get; private set; }
        public T Value { get; private set; }
        public Exceptional(T value)
        {
            HasException = false;
            Value = value;
        }
        public Exceptional(Exception exception)
        {
            HasException = true;
            Exception = exception;
        }
        public Exceptional(Func<T> getValue)
        {
            try
            {
                Value = getValue();
                HasException = false;
            }
            catch (Exception exc)
            {
                Exception = exc;
                HasException = true;
            }
        }
        public override string ToString()
        {
            return (this.HasException ? Exception.GetType().Name : ((Value != null) ? Value.ToString() : "null"));
        }
    }
