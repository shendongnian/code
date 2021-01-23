    static long Parse(params int[] parts)
    {
        long num = 0;
        foreach (int part in parts)
            num = num * 1000 + part;
        return num;
    }
    long foo = Parse(6,235,449,243,234);
