    class Foo
    {
        public bool SomeBool { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var foo = MaybeFoo();
            var bar = foo != null && foo.SomeBool;
        }
        static Foo MaybeFoo()
        {
            return new Random().Next() < 10 ? null : new Foo();
        }
    }
