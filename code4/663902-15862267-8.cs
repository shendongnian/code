    int[] numbers = new int[SIZE] { 5, 5, 5, 7, 7, 7, 9, 7, 9, 9, 9, 1 };
    string[] letters = new string[SIZE] { "m", "m", "s", "m", "s", "s", "s", "m", "s", "s", "s", "s" };
    int[] values = new int[SIZE] { 15, 22, 67, 45, 12, 21, 24, 51, 90, 60, 50, 44 };
    string[] status = new string[SIZE] { "f", "m", "f", "a", "m", "f", "f", "f", "m", "f", "m", "f" };
    // Set the size of Count to maximum value in numbers + 1
    int[] Count = new int[9 + 1];
    int x = 0;
    int i = 0;
    for (i = 0; i < SIZE - 1; i++)
    {
        if (numbers[i] > 0 && numbers[i] < SIZE)
        {
            // Use value from numbers as the index for Count and increment the count
            Count[numbers[i]]++;
        }
    }
    for (i = 0; i < Count.Length; i++)
    {
        // Check all values in Count, printing the ones where the count is 4
        if (Count[i] == 4)
            Console.WriteLine("{0}", i);
    }
