    class Program
    {
        abstract class aBaz
        {
            public abstract int A { get; }
        }
        interface IBar
        {
            int B { get; }
        }
        class Foo
        {
            public int C { get; }
        }
        class BarableFoo : Foo, IBar
        {
            public int C { get; }
        }
        static void Main()
        {
            // This is why the compiler doesn't error on the later cast
            Foo foo = new BarableFoo();
            // compiler error: aBaz is a class and the compiler knows that
            // Foo is not a _subclass_ of aBaz.
            aBaz baz = (aBaz)foo;
            // no compiler error: the class Foo does not implement IBar, however at runtime
            // this instance, "foo", might be a subclass of Foo that _implements_ IBar.
            // This is perfectly valid, and succeeds at runtime.
            IBar bar = (IBar)foo;
            // On the other hand...
            foo = new Foo();
            // This fails at runtime as expected. 
            bar = (IBar)foo;
        }
    }
