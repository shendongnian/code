    public interface ISomeInterface
    {
        object GetValue();
    }
    
    public class SomeClass : ISomeInterface
    {
        public string GetValue() { return "Hello world"; }
    }
