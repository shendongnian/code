    class Program
    {
        static void Main(string[] args)
        {
            MyMethod();
        }
        public static void MyMethod([CallerMemberName] String caller = null)
        {
            Console.WriteLine(caller); // Outputs Main
        }
    }
