    static void Main(string[] args)
    {
        List<int> original = new List<int>(new int[] { 4, 75, 12, 65, 2, 71, 56, 33, 78,1, 4, 56, 85, 12, 5,77, 32, 5 });
        List<int> sorted = mergeSort(original);
        for (int k = 0; k < sorted.Count; k++)
            Console.Write(sorted[k] + ",");
    }
