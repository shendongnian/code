    class Foo
    {
        public int Num { get; set; }
    }
    static void Main(string[] args)
    {
        Foo foo = new Foo() { Num = 7 };
        Console.WriteLine(typeof(Foo).GetProperty("Num").GetValue(foo, null));
    }
