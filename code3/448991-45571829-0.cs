    public static int LeftSegmentIndex(double[] array, double t)
    {
        int index = Array.BinarySearch(array, t);
        if (index < 0)
        {
            index = ~index - 1;
        }
        return Math.Min(Math.Max(index, 0), array.Length - 2);
    }
