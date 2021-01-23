    class FooReader<T> where T : IFoo, new()
    {
        public int Read()
        {
            var foo = new T();
            return foo.Read();
        }
    }
    class Foo : IFoo
    {
        public int Read()
        {
            return 42;
        }
    }
    interface IFoo
    {
        int Read();
    }
