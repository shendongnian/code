    public static string NewVer(string oldVer)
    {
        string newVer = oldVer.Trim();
        if (string.IsNullOrEmpty(newVer)) return oldVer;
        if (newVer.Length > 3) return oldVer;
        Char[] chars = newVer.ToCharArray();
        if (!char.IsDigit(chars[chars.Length - 1])) return oldVer;
        byte lastDigit = byte.Parse(chars[chars.Length - 1].ToString());
        if (newVer.Length == 3 && lastDigit == 9) return oldVer;
        lastDigit++;
        StringBuilder sb = new StringBuilder();
        for (byte i = 0; i < chars.Length-1; i++)
        {
            sb.Append(chars[i]);
        }
        sb.Append(lastDigit.ToString());
        return sb.ToString();
    }
