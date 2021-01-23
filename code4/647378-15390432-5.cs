    using System.Security.Cryptography;
    private static readonly char[] ValidPasswordChars = { 'A', 'B', ... };
    public string GetPassword(int length = 13)
    {
        var result = new char[length];
        var pool = GetPool(length);
        for (var i = 0; i < length; i++)
        {
            result[i] = PickChar(ValidPasswordChars, pool, i * sizeof(uint));
        }
        return new string(result);
    }
    private static byte[] GetPool(long length)
    {
        var rng = new RNGCryptoServiceProvider();
        var pool = new byte[length * sizeof(uint)];
        rng.GetBytes(pool);
        return pool;
    }
    private static char PickChar(IList<char> valid, byte[] pool, int offset)
    {
        long diff = valid.Count;
        var rand = BitConvertor.ToUInt32(pool, offset);
        var i = (int)(rand % diff);
        return valid[i];
    }
