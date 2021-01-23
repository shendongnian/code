    private int IndexOfNth(string str, char c, int n)
    {
        int remaining = n;
        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] == c)
            {
                remaining--;
                if (remaining == 0)
                {
                    return i;
                }
            }
        }
        return -1;
    }
