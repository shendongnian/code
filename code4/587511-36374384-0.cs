    public static void FindMax()
    {
        // Advantages: 
        // * Functional approach
        // * Compact code
        // Cons: 
        // * We are indexing into the array twice at each step
        // * The Range and IEnumerable add a bit of overhead
        // * Many people will find this code harder to understand
        int[] array = { 1, 5, 2, 7 };
        int maxIndex = Enumerable.Range(0, array.Length).Aggregate((max, i) => array[max] > array[i] ? max : i);
        int maxInt = array[maxIndex];
        Console.WriteLine($"Maximum int {maxInt} is found at index {maxIndex}");
    }
    public static void FindMax2()
    {
        // Advantages: 
        // * Near-optimal performance
        int[] array = { 1, 5, 2, 7 };
        int maxIndex = -1;
        int maxInt = Int32.MinValue;
        // Modern C# compilers optimize the case where we put array.Length in the condition
        for (int i = 0; i < array.Length; i++)
        {
            int value = array[i];
            if (value > maxInt)
            {
                maxInt = value;
                maxIndex = i;
            }
        }
        Console.WriteLine($"Maximum int {maxInt} is found at index {maxIndex}");
    }
