    interface IFoo
    {
        string Bar { get; }
    }
    class FooBase : IFoo
    {
        public virtual string Bar { get; protected set; }
    }
    class Foo : FooBase
    {
        public override string Bar { get; protected set; }
    }
