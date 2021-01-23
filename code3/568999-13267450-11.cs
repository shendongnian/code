    if(arg == "a")
        using LibraryA;
    if(arg == "b")
        using LibraryB;
    namespace Project
    {
        public class MyClass
        {
            public void Bar()
            {
                var foo = new Foo();
                foo.DoSomething();
            }
        }
    }
