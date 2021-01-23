        Console.Write("How big of an Array? ");
        int arraySize = int.Parse(Console.ReadLine());
        int[] array = new int[arraySize];
        for (int i = 0; i < arraySize; i++)
        {
            Console.Write("Value: ");
            int value = int.Parse(Console.ReadLine());
            array[i] = Convert.ToInt32(value);
        }
