    public interface IXAttribute
    {
        string Name { get; set; }
        object GetValue();
    }
    
    public class XAttribute<T> : IXAttribute<T>
    {
        public T Value { get; set; }
        public object GetValue()
        {
           return Value;
        }
    }
