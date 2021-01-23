    using System.Security.Cryptography;
    ...
    
    RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
    byte[] bytes = new byte[8];
    crypto.GetBytes( bytes );
    long value = BitConverter.ToInt64( bytes, 0 );
