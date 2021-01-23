     Console.Write("Enter min: ");
            int min = int.Parse(Console.ReadLine());
            Console.Write("Enter max: ");
            int max = int.Parse(Console.ReadLine());
            Console.WriteLine("The numbers dividable by 5 without remainder from {0} to {1} are: ", min, max);
            for (int i = min; i <= max; i++)
            {
                if (i % 5 != 0)
                
                continue;
                Console.WriteLine(i);
                    
