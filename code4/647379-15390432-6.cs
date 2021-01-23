    using System.Security.Cryptography;
    static string GetPassword(int length = 13)
    {
       var rng = new RNGCryptoServiceProvider();
       var buffer = new byte[length * sizeof(char)];
       rng.GetNonZeroBytes(buffer);
       return new string(Encoding.Unicode.GetChars(buffer));
    }
