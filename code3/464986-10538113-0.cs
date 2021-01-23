        static void Main(string[] args)
        {
            var items = new[] { 1, 2, 3 };
            var list = items.Select(i => Foo(i)).ToList(); // R# suggests "Convert to method group"
        }
        static int Foo(int i)
        {
            return i;
        }
