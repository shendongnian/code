    public class Program
    {
        public static void Main()
        {
            var foo = new Foo
            {
                Bar = new Bar
                {
                    HelloReflection = "Testing"
                }
            };
            string currentValue;
            if (foo.Bar.TryGetPropertyValue("HelloReflection", out currentValue))
            {
                Console.WriteLine(currentValue); // "Testing"
            }
            if (foo.Bar.TrySetProperty("HelloReflection", "123..."))
            {
                foo.Bar.TryGetPropertyValue("HelloReflection", out currentValue)
                Console.WriteLine(currentValue); // "123.."
            }
            else
            {
                Console.WriteLine("Failed to set value");
            }
        }
    }
    public class Foo
    {
        public object Bar { get; set; }
    }
    public class Bar
    {
        public string HelloReflection { get; set; }
    }
