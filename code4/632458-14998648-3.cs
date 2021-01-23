    static string Generate(int length)
    {
        // also, seed your random so you don't get the same password
        Random random = new Random((int)DateTime.Now.Ticks);
        char[] chars = "$%#@!*abcdefghijklmnopqrstuvwxyz1234567890?;:ABCDEFGHIJKLMNOPQRSTUVWXYZ^&".ToCharArray();
        string password = string.Empty;
        for (int i = 0; i < chars.Length; i++)
        {
            int x = random.Next(0, chars.Length);
            if (!password.Contains(chars.GetValue(x).ToString()))
                password += chars.GetValue(x);
            else
                i--;
        }
        if (length < password.Length) password = password.Substring(0, length);
        return password;
    }
