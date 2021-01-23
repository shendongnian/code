    public abstract class BaseClass<T>
    {
        public string Name { get; set; }
        public Unit Unit { get; set; }
        public T Value { get; set; }
    
        public override string ToString()
        {
            return Value.ToString();
        }
    }
    
    public class DerivedFloat : BaseClass<float> {}
    
    public class DerivedString : BaseClass<string> {}
