    public interface IMyInterface2
    {
        T My<T>(t value);
    }
    public class MyClass21 : IMyInterface2
    {
        public string My<string>(string value) { return value; }
    }
    
    public class MyClass22 : IMyInterface2
    {
        public int My<int>(int value) { return value; }
    }
