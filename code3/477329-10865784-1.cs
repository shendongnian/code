    class Program
    {
        public Program() : this(0)
        {
            Console.WriteLine("first");
        }
        public Program(int i)
        {
            Console.WriteLine("second");
        }
        static void Main(string[] args)
        {
            Program p = new Program();
        }
    }
