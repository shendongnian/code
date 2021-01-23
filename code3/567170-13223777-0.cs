    Console.Write("Enter min: ");
            int min = int.Parse(Console.ReadLine());
            Console.Write("Enter max: ");
            int max = int.Parse(Console.ReadLine());
            Console.WriteLine("The numbers devidable by 5 without remainder from {0} to {1} are: ",min,max);
            int count = 0;
            for (int i = min; i <= max; i++)
            {
                if (i % 5 == 0)
                {
                    Console.WriteLine(i);
                    count++;
                }
            }
            Console.WriteLine(count);
