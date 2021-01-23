    [Flags() 
    enum Week
    {
        Monday = 1,
        Tuesday = 2,
        Wednesday = 4,
        Thursday = 16,
        Friday = 32,
        Saturday = 64,
        Sunday = 128
    }
    const string strFullWeek = "MTWtFSs";
    string GetMaskedWeek(Week days)
    {
        char[] result = new char[strFullWeek.Length];
        for (int i = 0; i < strFullWeek.Length; i++)
        {
            if ((((int)days >> i) & 1) != 0)
                result[i] = strFullWeek.ToCharArray(i, 1)[0];
            else
                result[i] = '-';
        }
        return new string(result);
    }
