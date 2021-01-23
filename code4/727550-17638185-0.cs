    static string LittleEndian(string num)
    {
        int number = Convert.ToInt32(num, 16);
        byte[] bytes = BitConverter.GetBytes(number);
        string retval = "";
        foreach (byte b in bytes)
            retval += b.ToString("X2");
        return retval;
    }
