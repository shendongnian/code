    public static String SpinNoRE(String text)
    {
        int i, j, e = -1;
        char[] curls = new char[] {'{', '}'};
        text += '~';
        
        do
        {
            i =  e;
            e = -1;
            while ((i = text.IndexOf('{', i+1)) != -1)
            {
                j = i;
                while ((j = text.IndexOfAny(curls, j+1)) != -1 && text[j] != '}')
                {
                    if (e == -1) e = i;
                    i = j;
                }
                if (j != -1)
                {
                    parts = text.Substring(i+1, (j-1)-(i+1-1)).Split('|');
                    text = text.Remove(i, j-(i-1)).Insert(i, parts[rand.Next(parts.Length)]);
                }
            }
        }
        while (e-- != -1);
        
        return text.Remove(text.Length-1);
    }
