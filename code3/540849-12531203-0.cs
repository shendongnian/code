    enum DaysOfWeek
    {
        Monday = 1,
        Tuesday = 2,
        Wednesday = 4,
        Thursday = 8,
        Friday = 16,
        Saturday = 32,
        Sunday = 64
    }
    const string strFullWeek = "MTWtFSs";
    string GetMaskedWeek(DaysOfWeek days)
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
