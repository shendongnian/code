    partial class Foo
    {
        public string Bar { get; set; }
    }
    interface IFoo
    {
        string Bar { get; set; }
    }
    partial class Foo : IFoo
    {
    }
