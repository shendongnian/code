    public static int GetArgbValues(Color c)
    {
        string colorcode = c.ToString();
        int argb = Int32.Parse(colorcode.Replace("#", ""), NumberStyles.HexNumber);
        return argb;
    }
