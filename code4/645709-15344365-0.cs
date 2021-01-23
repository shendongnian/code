    public class IFoo: Foo
    {
        public string S2 { get; set; }
        public IFoo(){}
        public IFoo(Foo other)
        {
            S1 = other.S1;
        }
    }
