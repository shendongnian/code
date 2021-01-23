    public class Program
    {
        static Program()
        {
            Console.WriteLine("line no 1");
            Console.WriteLine("line no 2");
            Console.WriteLine("line no 3");
            Environment.Exit(0);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("line no 2");
        }
    }
