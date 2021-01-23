    public class Test
    {
        public string Item { get; set; }
    }
    class Program
    {
        void run()
        {
            Test test = new Test { Item = "Initial Item" };
            Console.WriteLine(test.Item); // Prints "Initial Item"
            var wrapper = new PropertyWrapper<string>(test, "Item");
            Console.WriteLine(wrapper.Value); // Prints "Initial Item"
            wrapper.Value = "Changed Item";
            Console.WriteLine(wrapper.Value); // Prints "Changed Item"
        }
        static void Main()
        {
            new Program().run();
        }
    }
