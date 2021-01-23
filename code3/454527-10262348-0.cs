    public abstract class BaseClass<T>
    {
        public string Name { get; set; }
        public Unit Unit { get; set; }
        public T Value { get; set; }
    }
    public class DerivedClassFloat : BaseClass<float>
    {
        public override string ToString()
        {
            return Value.ToString();
        }
    }
    public class DerivedClassString : BaseClass<string>
    {
        public override string ToString()
        {
            return Value;
        }
    }
