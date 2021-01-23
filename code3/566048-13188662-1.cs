            int number = int.Parse(Console.ReadLine());
            if (number == 1)
            {    Console.WriteLine("Number 1 is prime");return;}
            for (int i = 2; i < number / 2 + 1; i++)
            {
                bool isPrime = (number % i == 0);
                if (isPrime)
                {
                    Console.WriteLine("Number {0} is not prime", number);
                    return;
                }
            }
            Console.WriteLine("Number {0} is prime", number);
