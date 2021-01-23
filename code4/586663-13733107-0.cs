    public interface IFoo<T>
    {
        T Method();
    }
    
    public class IntFoo : IFoo<int>
    {
        int value;
        public IntFoo(int value)
        {
            this.value = value;
        }
    
        public int Method()
        {
            return value;
        }
    }
    
    public class StringFoo : IFoo<string>
    {
        string value;
        public StringFoo(string value)
        {
            this.value = value;
        }
    
        public string Method()
        {
            return value;
        }
    }
