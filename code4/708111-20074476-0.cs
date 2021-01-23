    public class Foo
    {
        public string Bar { get; private set; }
    }
    // .....
        internal static void Main()
        {
            Foo foo = new Foo();
            foo.GetType().GetProperty("Bar").SetValue(foo, "private?", null);
            Console.WriteLine(foo.Bar);
        }
