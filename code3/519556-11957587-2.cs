    public static string Reverse(string input)
    {
        var length = input.Length;
        var last = length - 1;
        var chars = input.ToCharArray();
        for (int i = 0; i < length / 2; i++)
        {
            var c = chars[i];
            chars[i] = chars[last - i];
            chars[last - i] = c;
        }
        return new string(chars);
    }
