     static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int theNum = int.Parse(Console.ReadLine());
            if (theNum < 3)  // special case check, less than 3
            {
                if (theNum == 2)
                {
                    // The only positive number that is a prime
                    Console.WriteLine("{0} is a prime!", theNum);
                }
                else
                {
                    // All others, including 1 and all negative numbers, 
                    // are not primes
                    Console.WriteLine("{0} is not a prime", theNum);
                }
            }
            else
            {
                if (theNum % 2 == 0)
                {
                    // Is the number even?  If yes it cannot be a prime
                    Console.WriteLine("{0} is not a prime", theNum);
                }
                else
                {
                    // If number is odd, it could be a prime
                    int div;
                    // This loop starts and 3 and does a modulo operation on all
                    // numbers.  As soon as there is no remainder, the loop stops.
                    // This can be true under only two circumstances:  The value of
                    // div becomes equal to theNum, or theNum is divided evenly by 
                    // another value.
                    for (div = 3; theNum % div != 0; div += 2)
                        ;  // do nothing
                    if (div == theNum)
                    {
                        // if theNum and div are equal it must be a prime
                        Console.WriteLine("{0} is a prime!", theNum);
                    }
                    else
                    {
                        // some other number divided evenly into theNum, and it is not
                        // itself, so it is not a prime
                        Console.WriteLine("{0} is not a prime", theNum);
                    }
                }
            }
            Console.ReadLine();
        }
