    public class Program
    {
        private static readonly string Foo = "Bar";
    
        static void Main()
        {
            typeof(Program)
                .GetField("Foo", BindingFlags.Static | BindingFlags.NonPublic)
                .SetValue(null, "new value");
            Console.WriteLine(Foo);
        }
    }
