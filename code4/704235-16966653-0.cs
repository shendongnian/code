    public static int GetInt(int number)
    {
        int[] ints = new int[]{ 3, 7, 9, int.MaxValue };
        return ints.First(i => number <= i);
    }
