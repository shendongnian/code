     class Program
    {
        static void Main(string[] args)
        {
            foreach (uint digit in Calculator.Pi().Take(100))
            {
                Console.WriteLine(digit);
            }
            Console.Read();
        }
    }
 
