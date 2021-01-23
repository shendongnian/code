    String input = "[abc]";
    String removed = input.RemoveChars(new[] { '[', ']' });
    public static String RemoveChars(this string input, char[] charsToRemove)
    {
        Array.Sort(charsToRemove);
        StringBuilder sb = new StringBuilder();
        foreach (char c in input)
        {
            if (Array.BinarySearch(charsToRemove, c) == -1)
                sb.Append(c);
        }
        return sb.ToString();
    }
