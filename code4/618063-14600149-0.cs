    public static void SmallestMultiple()
    {
        for (int value = 19; ; value += 19)
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
