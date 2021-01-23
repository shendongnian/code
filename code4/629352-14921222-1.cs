    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(RecursiveTest.Foo(new DirectoryInfo(@"d:\dev")));
            Console.ReadLine();
        }
    }
