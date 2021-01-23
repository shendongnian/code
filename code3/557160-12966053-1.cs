    public long Sum(params int[] arr)
    {
        long total = 0;
        for (int n = 0; n < arr.Length; n++)
        {
            total += arr[n];
        }
        return total;
    }
