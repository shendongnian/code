    class Program
    {
        static void Main(string[] args)
        {
            ModulusHelper mod = new ModulusHelper(args[0], args[1]);
            Console.WriteLine("Quotient:  {0}", mod.Quotient);
            Console.WriteLine("Remainder: {0}", mod.Remainder);
            Console.ReadKey(); // BATCH `pause`
        }
    }
