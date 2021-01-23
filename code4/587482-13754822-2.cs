    using Org.BouncyCastle.Crypto.Parameters;
    using Org.BouncyCastle.Crypto;
    using Org.BouncyCastle.Security;
    using Org.BouncyCastle.OpenSsl;
    using System.IO;
    using System.Security.Cryptography;
    //elsewhere
            using (var reader = File.OpenText(fileName))
            {
                var pemReader = new PemReader(reader);
                var bouncyRsaParameters = (RsaPrivateCrtKeyParameters)pemReader.ReadObject();
                var rsaParameters = DotNetUtilities.ToRSAParameters(bouncyRsaParameters);
                this.PrivateKey = new RSACryptoServiceProvider();
                this.PrivateKey.ImportParameters(rsaParameters);
            }
