    using Org.BouncyCastle.Crypto.Parameters;
    using Org.BouncyCastle.Crypto;
    using Org.BouncyCastle.Security;
    using Org.BouncyCastle.OpenSsl;
    using System.IO;
    using System.Security.Cryptography;
    //elsewhere
            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(prvkey);
