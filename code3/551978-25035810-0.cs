    static void SwapInts(int[] array, int position1, int position2)
    {
        // Swaps elements in an array.
        int temp = array[position1]; // Copy the first position's element
        array[position1] = array[position2]; // Assign to the second element
        array[position2] = temp; // Assign to the first element
    }
    static void Main()
    {                                                
        Random rng = new Random();
        int n = int.Parse(Console.ReadLine());
        int[] intarray = new int[n];
        for (int i = 0; i < n; i++)
        {
            // Initialize array
            intarray[i] = i + 1;
        }
        // Exchange resultArray[i] with random element in resultArray[i..n-1]
        for (int i = 0; i < n; i++)
        {
            int positionSwapElement1 = i + rng.Next(0, n - i);
            SwapInts(intarray, i, positionSwapElement1);
        }
        for (int i = 0; i < n; i++)
        {
            Console.Write(intarray[i] + " ");
        }
    }
}
