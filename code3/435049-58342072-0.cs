            Console.WriteLine("Enter first number: ");
            int first = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter second number: ");
            int second = int.Parse(Console.ReadLine());
            if (first % second == 0) 
            {
                Console.WriteLine("Number 1 is multiple of number 2.");
            }
            else if (second % first == 0)
            {
                Console.WriteLine("Number 2 is multiple of number 1.");
            }
            else
            {
                Console.WriteLine("Numbers are not multiples.");
            }
            Console.ReadKey();
