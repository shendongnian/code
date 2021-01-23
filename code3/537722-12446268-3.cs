    public static void Swap(this Array a, int indexOne, int indexTwo)
    {
        if (indexOne < 0 | indexOne >= a.Length)
            throw new ArgumentOutOfRangeException(...);
        if (indexTwo < 0 | indexTwo >= a.Length)
            throw new ArgumentOutOfRangeException(...);
        Swap(a[indexOne], a[indexTwo]);
    }
