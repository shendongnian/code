    private static int[] Shuffle(int[] singleArray)
    {
        var random = new Random();
        for (int i = singleArray.Length; i > 1; i--)
        {
            // Pick random element to swap.
            int j = random.Next(i); // 0 <= j <= i-1
            // Swap.
            int tmp = singleArray[j];
            singleArray[j] = singleArray[i - 1];
            singleArray[i - 1] = tmp;
        }
        return singleArray;
    }
