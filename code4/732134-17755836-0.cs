    using System.Linq;
    
    private static Random _random = new Random();
    public static int[] GenerateRandomArray(int arrayLength)
    {
        return Enumerable.Range(0, arrayLength).Select(i => _random.Next(0, 100)).ToArray();
    }
    public static int FindMaxValue(int[] array)
    {
        return array.Max();
    }
