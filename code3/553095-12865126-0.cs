    static class Foo 
    {
        private static IFoo _foo;
        public static void SetFoo(IFoo foo) { _foo = foo; }
        public static string GetBar() { return _foo.GetBar(); }
    }
