    public interface IFooSetup
    {
        IReadOnlyList<object> Params{get;}
        string Opt{get;}
    }
    public class FooSetup : IFooSetup
    {
        public IReadOnlyList<object> Params { get; set; }
        public string Opt { get; set; }
        public FooSetup()
        {
            Opt = "empty";
            Params = new List<object>();
        }
    }
    public void Foo(int req, IFooSetup setup)
    {
    }
