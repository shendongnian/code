    public interface IFoo
    {
        void Bar();
    }
    public class Foo : IFoo
    {
        // implementation of interface method
        public void Bar()
        {
        }
    
        // not contained in interface
        public void FooBar()
        {
        }
    }
    var foo = new Foo();
    Class1.Test1(foo).FooBar(); // <- valid
    Class1.Test2(foo).FooBar(); // <- invalid
