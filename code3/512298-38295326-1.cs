            static void Main(string[] args)
        {
            
            for (int i = 1; i <= 100; i++)
            {
                if(  ((i % 3) != 0) && ((i % 5) != 0))
                {
                    WriteLine($"{i}");
                }
                else
                {
                    if ((i % 15) == 0)
                    {
                        WriteLine("FizzBuzz");
                    }
                    else if ((i % 3) == 0)
                    {
                        WriteLine("Fizz");
                    }
                    else if ((i % 5) == 0)
                    {
                        WriteLine("Buzz");
                    }
                }                 
            }
        }
