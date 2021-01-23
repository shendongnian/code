    public interface IBar
    {
        void DoSomethingWithBar();
    }
    public interface IMyStringPrameterForBar
    {
        string Value { get; }
    }
    public class MyStringPrameterForBar : IMyStringPrameterForBar
    {
        public string Value { get; }
        public MyStringPrameterForBar(string value) => Value = value; 
    }
    public class Bar : IBar
    {
        public Bar(IFoo foo, IFoo2 foo2, IFoo3 foo3, IFooN fooN, IMyStringPrameterForBar text)
        {
        }
        
        public void DoSomethingWithBar() {}
    }
