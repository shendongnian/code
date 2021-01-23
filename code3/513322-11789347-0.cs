    public static string ToStringWithSign(this double d, int digits) {
        string fmt = "G" + digits.ToString();
        string s = d.ToString(fmt);
        if (!s.StartsWith("-"))
            s = "+" + s;
        return s;
    }
