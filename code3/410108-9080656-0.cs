    public sealed class MyHMACSHA512 : HMAC
    {
        public MyHMACSHA512(byte[] key)
        {
            if (key == null)
                throw new ArgumentNullException("key");
     
            HashName = "SHA512CryptoServiceProvider";
            HashSizeValue = 512;
            BlockSizeValue = 128;
            InitializeKey(key);
        }
    }
