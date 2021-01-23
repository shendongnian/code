    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(System.Reflection.Assembly.GetCallingAssembly()
                                                        .FullName);
            Console.ReadLine();
        }
    }
