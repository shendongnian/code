    public static string encrypt(string s)
    {
        int length = s.Length, i = 0;
        char[] chArray = new char[length];
        byte b1, b2;
        char ch;
        for (i = 0; i <= chArray.Length - 1; i++)
        {
            ch = s[i];
            b1 = Convert.ToByte((ch ^ (length - i)));
            b2 = Convert.ToByte(((ch >> 8) ^ i));
            chArray[i] = (char)((b2 << 8) | b1);
        }
        return string.Intern(new string(chArray));
    }
