    int a = Convert.ToInt32(number);
    
    if (a % 2 != 0)
    {
        for (int i = 3 i <= a; i += 2) // we can skip all the even numbers (minor optimization)
        {
            if (a % i == 0)
            {
                Console.WriteLine("not prime");
                goto escape; // we want to break out of this loop
            }
            // we know it isn't divisible by i or any primes smaller than i, but that doesn't mean it isn't divisible by something else bigger than i, so keep looping 
        }
        // checked ALL numbers, must be Prime
        Console.WriteLine("prime");
    }
    else
    {
        Console.WriteLine("not prime");
    }
    escape:
    Console.ReadLine();
