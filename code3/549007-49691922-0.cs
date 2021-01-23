    public interface IFoo
    {
        string ConstValue { get; }
    }
    
    public class Foo : IFoo
    {
        public string ConstValue => _constValue;
        private string _constValue = "My constant";
    }
