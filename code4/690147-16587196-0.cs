    interface IFoo
    {
        public string Bar { get; }
    }
    class FooBase : IFoo
    {
        public virtual string Bar { get; }
    }
    class Foo : FooBase
    {
        public override string Bar { get; }
    }
