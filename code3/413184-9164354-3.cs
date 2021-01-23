    public static void Scramble<T>(T[] array, int key)
    {
        var random = new Random(key);
        for (int i = array.Length; i > 1; i--)
        {
            int j = random.Next(i);
            Swap(array, j, i - 1);
        }
    }
    public static void Unscramble<T>(T[] array, int key)
    {
        var random = new Random(key);
        List<int> swap1 = new List<int>(array.Length);
        List<int> swap2 = new List<int>(array.Length);
        for (int i = array.Length; i > 1; i--)
        {
            int j = random.Next(i);
            swap1.Add(j);
            swap2.Add(i - 1);
        }
        swap1.Reverse();
        swap2.Reverse();
        for (int i = 0 ; i < swap1.Count; ++i)
        {
            Swap(array, swap1[i], swap2[i]);
        }
    }
