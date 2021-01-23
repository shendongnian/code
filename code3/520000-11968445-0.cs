        static void Main()
        {
            Console.WriteLine("Press t for two table");
            char c1 = Convert.ToChar(Console.ReadLine());
            char c2 = Convert.ToChar(Console.ReadLine());
            if (c1 == 't' && c2 == 't')
            {
                twotable.two();
            }
            else
            {
                Console.WriteLine("i hate u");
            }
        }
