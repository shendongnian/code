    public interface IValue<T> { T GetValue(); }
    public class SomeClass : IValue<int>, IValue<string>
    {
        string IValue<string>.GetValue() { return "abc"; }
        int IValue<int>.GetValue() { return 1; }
    }
