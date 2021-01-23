    public static string Convert(int x)
    {
        if (x == 0)
        {
            return "0";
        }
        StringBuilder sb = new StringBuilder();
        string prefix = "";
        if (x < 0)
        {
            prefix = "-";
            x = -x;
        }
        while (x != 0)
        {
            sb.Insert(0, (char)(x % 10 + '0'));
            x = x / 10;
        }
        return prefix + sb.ToString();
    }
