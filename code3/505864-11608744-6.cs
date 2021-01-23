    readonly static Char[] letters = 
        "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();
    static String appendChars(int n)
    {
        int length = n + 1;
        StringBuilder sBuilder = new StringBuilder("A", length);
        for (int i = n; sBuilder.Length < length; i += n)
        {
            Char nextChar = letters[i % letters.Length];
            sBuilder.Append(nextChar);
        }
        return sBuilder.ToString();
    }
    
