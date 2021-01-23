    public static string[] SplitFixedWidth(string original, bool spaceBetweenItems, params int[] widths)
    {
        string[] results = new string[widths.Length];
        int current = 0;
        for (int i = 0; i < widths.Length; ++i)
        {
            if (current < original.Length)
            {
                int len = Math.Min(original.Length - current, widths[i]);
                results[i] = original.Substring(current, len);
                current += widths[i] + (spaceBetweenItems ? 1 : 0);
            }
            else results[i] = string.Empty;
        }
        return results;
    }
