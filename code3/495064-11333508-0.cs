    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello world!");
    #if DEBUG
            Console.WriteLine("Inside #if block.");
    #endif
            WriteLine("With ConditionalAttribute.");
            Debug.WriteLine("Debug.WriteLine.");
        }
        [Conditional("DEBUG")]
        public static void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
