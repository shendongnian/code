    public class MyHMACSHA512 : HMAC
    {
        public MyHMACSHA512(byte[] key)
        {
            HashName = "System.Security.Cryptography.SHA512CryptoServiceProvider";
            HashSizeValue = 512;
            BlockSizeValue = 128;
            Key = key;
        }
    }
