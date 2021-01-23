        private byte[] GetFileSha1Hash(string file)
        {
            using (var fs = new FileStream(
                file, FileMode.Open))
            {
                return new SHA1CryptoServiceProvider().ComputeHash(fs);
            }
        }
        static string GetConfigurationFileSignature(string configfile, string privateXml)
        {
            var p = new RSACryptoServiceProvider();
            p.FromXmlString(privateXml);
            byte[] signature = p.SignHash(GetFileSha1Hash(configfile),
                   CryptoConfig.MapNameToOID("SHA1"));
            return Convert.ToBase64String(signature)
        }
