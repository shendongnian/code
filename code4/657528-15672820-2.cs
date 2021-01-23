    public static void RandomizeArray(out int[] array)
    {
        int intRead;
        int intReadSeed;
        Random randomNum = new Random();
        Console.WriteLine("How many ints do you want to randomly generated?");
        intRead = Convert.ToInt32(Console.ReadLine());
        array = new int[intRead];
        Console.WriteLine("What's the maximum value of the randomly generated ints?");
        intReadSeed = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < intRead; i++)
        {
            array[i] = (randomNum.Next(intReadSeed));
        }
        Console.WriteLine("Randomization Complete.\n");
    }
