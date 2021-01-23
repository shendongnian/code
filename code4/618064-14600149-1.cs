    public static void SmallestMultiple()
    {
        // this is a bit quick and dirty
        //   (not too difficult to change to generate primeProduct dynamically for any range)
        int primeProduct = 2*3*5*7*11*13*17*19;
        for (int value = primeProduct; ; value += primeProduct)
        {
           bool success = true;
            for (int j = 11; j < 21; j++)
            {
                if (value % j != 0)
                {
                    success = false;
                    break;
                }
            }
            if (success)
            {
                Console.WriteLine("The value is {0}", value);
                break;
            }
        }
    }
