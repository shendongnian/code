    public static int? TryParse(string str)
    {
        int result;
        if (Int32.TryParse(str, out result))
        {
            return result;
        }
        else
        {
            return null;
        }
    }
