    class Program
    {
        static void Main(string[] args)
        {
        }
        interface IFoo
        {
            void Foo();
        }
        class Bar<T> where T : IFoo, IDisposable
        {
            public Bar(T foo)
            {
                foo.Foo();
                foo.Dispose();
            }
        }
    }
