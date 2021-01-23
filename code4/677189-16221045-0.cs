    class Program
    {
        private static Timer timer = new Timer(Write, null, TimeSpan.FromHours(1), TimeSpan.FromHours(1));
    
        static void Main(string[] args)
        {
        }
    
        static void Write(object data)
        {
            Console.WriteLine("foo");
        }
    }
