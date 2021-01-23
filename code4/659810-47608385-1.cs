            Console.Write("Please Enter a number: ");
            int number = int.Parse(Console.ReadLine());
            int count = 2; 
            // this is initial count number which is greater than 1
            bool prime = true;
            // used Boolean value to apply condition correctly
            int sqrtOfNumber = (int)Math.Sqrt(number); 
            // square root of input number this would help to simplify the looping.  
            while (prime && count <= sqrtOfNumber)
            {
                if ( number % count == 0)
                {
                Console.WriteLine($"{number} isn't prime and it divisible by 
                                          number {count}");  // this will generate a number isn't prime and it is divisible by a number which is rather than 1 or itself and this line will proves why it's not a prime number.
                    prime = false;
                }
                
                count++;
                
            }
            if (prime && number > 1)
            
            {
                Console.WriteLine($"{number} is a prime number");
            }
            else if (prime == true)
            // if input is 1 or less than 1 then this code will generate
            {
                Console.WriteLine($"{number} isn't a prime");
            }
            
