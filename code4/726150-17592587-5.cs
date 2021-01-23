    public static string TrimLongWords(string original, int maxCount)
    {
        if (null == original || original.Length <= maxCount) return original;
        StringBuilder builder = new StringBuilder(original.Length);
        int occurence = 0;
        for (int i = 0; i < original.Length; i++)
        {
            Char current = original[i];
            if (current == original.ElementAtOrDefault(i-1))
                occurence++;
            else
                occurence = 1;
            if (occurence <= maxCount)
                builder.Append(current);
        }
        return builder.ToString();
    }
