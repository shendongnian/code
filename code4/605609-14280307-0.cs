    public interface MyInternalInterface: MyPublicInterface
    {
        string MyProperty { set; }
    }
    public interface MyPublicInterface
    {
        string MyProperty { get; }
    }
    public class A: MyInternalInterface
    {
        public string MyProperty { get; set; }
    }
    public class Foo
    {
        private A _a = new A();
        internal MyInternalInterface GetInternalA() { return _a; }
        public MyPublicInterface GetA() { return _a; }
    }
