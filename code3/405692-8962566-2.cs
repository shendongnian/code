        static bool VerifyConfigurationFileSignature(string fileName, string publicXml, string signature)
        {
            var p = new RSACryptoServiceProvider();
            p.FromXmlString(publicXml);
            return p.VerifyHash(
                 GetFileSha1Hash(fileName),
                 CryptoConfig.MapNameToOID("SHA1"),
                 Convert.FromBase64String(signature));
        }
