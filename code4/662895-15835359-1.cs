    class Program
        {
            static void Main(string[] args)
            {
                Item a = new Item("Tennis Ball", 100);
                Item b = new Item("Spoon", 10);
                Item c = new Item("Candles", 27);
                Item d = new Item("Battery's", 2);
                Item e = new Item("Nails", 10);
                Item f = new Item("Marbles", 0);
    
                Console.WriteLine(a.CalculateDiscount());
                Console.WriteLine();
                Console.WriteLine(b.CalculateDiscount());
                Console.WriteLine();
                Console.WriteLine(c.CalculateDiscount());
                Console.WriteLine();
                Console.WriteLine(d.CalculateDiscount());
                Console.WriteLine();
                Console.WriteLine(e.CalculateDiscount());
                Console.WriteLine();
                Console.WriteLine(f.CalculateDiscount());
                Console.WriteLine();
                Console.ReadLine();
            }
