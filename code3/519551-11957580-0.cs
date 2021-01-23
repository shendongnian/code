    /// <summary>
    /// Reverses a string
    /// </summary>
    public static string ReverseString(this string s)
    {
        char[] arr = s.ToCharArray();
        Array.Reverse(arr);
        return new string(arr);
    }
