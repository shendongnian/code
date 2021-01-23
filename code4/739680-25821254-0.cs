        static void Main(string[] args)
        {
            int number, fact;
            Console.WriteLine("enter the number for geting factorial");
            number = Convert.ToInt32(Console.ReadLine());
            fact = number;
            for (int i = fact - 1; i > 0; i--)
            {
                fact = fact * i;
            }
            Console.WriteLine(fact);
            Console.ReadLine();
        }
    
