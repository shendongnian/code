    public abstract class Response
    {
        public abstract object ObjectValue { get; }
    }
    
    public class Response<T> : Response
    {
        public T Value { get; set; }
        
        public override object ObjectValue { get { return Value; } }
    }
