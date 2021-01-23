    public interface IMix<T>
    {
        T Mix(List<T> values);
    }
    
    public class ConcreteObjects : IMix<ConcreteObjects>
    {
        public ConcreteObjects Mix(List<ConcreteObjects> values)
        {
            // do mixing
        }
    }
