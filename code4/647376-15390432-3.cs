    using System.Security.Cryptography;
    private static readonly char[] ValidPasswordChars = { 'A', 'B', ... };
    private string GetPassword(int length = 13)
    {
        var result = new char[length];
        var pool = GetPool(length);
        for (var i = 0; i < length; i++)
        {
            result[i] = PickChar(ValidPasswordChars, pool, i * sizeof(uint));
        }
        return new string(result);
    }
    static byte[] GetPool(long length)
    {
        var rng = new RNGCryptoServiceProvider();
        var pool = new byte[length * sizeof(uint)];
        rng.GetBytes(pool);
        return pool;
    }
    static char PickChar(char[] valid, byte[] pool, int offset)
    {
        long diff = valid.Length - 1;
        var rand = BitConvertor.ToUInt32(pool, offset);
        var i = ((int)rand % diff) + 1;
        return valid[i];
    }
