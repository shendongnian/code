    public class Program
    {
        static void Main(string[] args)
        {
            string result = "";
            for (int i = 0; i < 10; i++)
                result += "a" + result;
            Console.ReadKey();
        }
    }
