    public class Program
    {
        static Program()
        {
            Thread thread = new Thread(Test);
            thread.Start();
            thread.Join();
        }
        
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, world!");
        }
        
        static void Test() { }
    }
