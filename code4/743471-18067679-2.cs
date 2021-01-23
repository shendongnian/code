    class Program
    {
        static void Main()
        {
            new C().Foo().ForEach(x => Console.WriteLine(x.Name));
            Console.Read();
        }
    }
