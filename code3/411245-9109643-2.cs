    static int Foo()
    {
        return Test.Foo;
    }
    static int Bar()
    {
        return Test.Bar;
    }
    ...
    static class Test
    {
        public static readonly int Foo = 123;
        public const int Bar = 456;
    }
