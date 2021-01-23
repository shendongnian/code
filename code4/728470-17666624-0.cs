    using System;
    using System.IO;
    using System.Security.Cryptography;
    void ConvertToBase64(string sourceFileName, string destFileName) {
      FileStream source = new FileStream(sourceFileName, FileMode.Open,
                                FileAccess.Read, FileShare.Read);
      FileStream dest = new FileStream(destFileName, FileMode.Create,
                              FileAccess.Write, FileShare.None);
      ICryptoTransform base64 = new ToBase64Transform();
      CryptoStream cryptoStream = new CryptoStream(dest, base64, CryptoMode.Write);
      using (source) using (dest) using (base64) using (cryptoStream) {
        source.CopyTo(cryptoStream);
        cryptoStream.FlushFinalBlock();
      }
    }
    void ConvertFromBase64(string sourceFileName, string destFileName) {
      FileStream source = new FileStream(sourceFileName, FileMode.Open,
                                FileAccess.Read, FileShare.Read);
      ICryptoTransform base64 = new FromBase64Transform();
      CryptoStream cryptoStream = new CryptoStream(source, base64, CryptoMode.Read);
      FileStream dest = new FileStream(destFileName, FileMode.Create,
                              FileAccess.Write, FileShare.None);
      using (source) using (base64) using (cryptoStream) using (dest) {
        cryptoStream.CopyTo(dest);
      }
    }
