    public class Foo
    {
        public Bar Bar { get; set; }
    }
    public class Bar
    {
        public string Value { get; set; }
    }
    public static void Main(string[] args)
    {
        var foo = new Foo { Bar = new Bar { Value = "Testing" } };
        foo.Cmp("Value", "Testing"); // True
    }
