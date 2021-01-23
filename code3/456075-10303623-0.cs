    [Flags]
    public enum Foo
    {
        Prop1 = 1,
        Prop2 = 1 << 1,
        Prop3 = 1 << 2
    }
    public static class FooExtensions
    {
        private static readonly Foo[] values = (Foo[])Enum.GetValues(typeof(Foo));
        public static IEnumerable<Foo> GetComponents(this Foo value)
        {
            return values.Where(v => (v & value) != 0);
        }
    }
    public static class Program
    {
        public static void Main(string[] args)
        {
            var foo = Foo.Prop1 | Foo.Prop3;
            var components = foo.GetComponents().ToArray();
        }
    }
