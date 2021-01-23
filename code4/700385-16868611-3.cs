    class Program
    {
        delegate void TestDelegate();
        static void Main(string[] args)
        {
            List<string> names = new List<string>() { "A", "B", "C" };
            var name = names[0];
            TestDelegate test = () => { Console.WriteLine(name); };
            name = names[1];
            test();
            Console.ReadLine();
        }
    }
