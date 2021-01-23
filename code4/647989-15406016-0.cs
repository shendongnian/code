    string password = string.Empty;
    for (int i = 0; i < length; i++)
    {
        int x = random.Next(0, chars.Length);
        password += chars.GetValue(x);
    }
