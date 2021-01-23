    readonly Char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();
    private String appendChars(int n) 
    {
        int length = n + 1;
        StringBuilder sBuilder = new StringBuilder(length);
        for(int i=0; sBuilder.Length < length; i+=n)
        {
            if (sBuilder.Length == 0)
                sBuilder.Append('A');
            else
            {
                Char nextChar = letters[i % letters.Length];
                sBuilder.Append(nextChar);
            }
        }
        return sBuilder.ToString();
    }
