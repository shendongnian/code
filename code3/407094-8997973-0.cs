    public static long Lines(this string s)
    {
        long count = 1;
        int position = 0;
        while ((position = s.IndexOf('\n', position)) != -1)
            {
            count++;
            position++;         // Skip this occurance!
            }
        return count;
    }
