    public static void SmallestMultiple()
    {
        const ushort ARRAY_SIZE = 21;
        ushort check = 0;
        for (uint value = 1; value < uint.MaxValue; value++)
        {
            for (ushort j = 1; j < ARRAY_SIZE; j++)
            {
                if (value % j == 0)
                {   
                    check++;
                }
            }
            if (check == 20)
            {
                Console.WriteLine("The value is {0}", value);
            }
            else
            {
                check = 0;
            }
        }
    }
