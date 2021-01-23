            string l = Console.ReadLine();
            int i;
            while(int.TryParse(l, out i) == false)
            {
                Console.WriteLine("Invalid input. Please enter 1, 2, or 3.");
                l = Console.ReadLine();
            }
