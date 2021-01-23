    var possibilities = "abcdefghijknpqrstuvxyz0123456789".ToCharArray();
    int goal = 1000000;
    int codeLength = 8;
    var codes = new HashSet<string>();
    var random = new RNGCryptoServiceProvider();
    while (codes.Count < goal)
    {
        var newCode = new char[codeLength];
        for (int i = 0; i < codeLength; i++)
            newCode[i] = possibilities[random.Next(possibilities.Length)];
        codes.Add(new string(newCode));
    }
    // now write codes to database
    static class Extensions
    {
        public static byte Next(this RNGCryptoServiceProvider provider, byte maximum)
        {
            var b = new byte[1];
            while (true)
            {
                provider.GetBytes(b);
                if (b[0] < maximum)
                    return b[0];
            }
        }
    }
