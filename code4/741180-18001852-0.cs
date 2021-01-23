    interface IFoo { void Go(); }
    class Foo : IFoo { public void Go() { } }
    class SomeOtherFoo : IFoo { public void Go() { } }
    IFoo foo = MyIoCLibrary.Get<IFoo>(); // instead of new Foo()
    foo.Go();
    or
    public class SomeClass : IWhatever {
        private IFoo _foo;
        // Your DI library will call this constructor automatically
        public SomeClass(IFoo foo) {
            _foo = foo;
        }
    }
