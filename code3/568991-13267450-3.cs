    // In Shared.dll
    public class Foo2Adapter : IFoo()
    {
        private Library2.Foo _realFoo;
        public Foo2Adapter()
        {
            _realFoo= new Library2.Foo();
        }
        public int DoSomething()
        {
            _realFoo.DoSomething();
        }
    }
