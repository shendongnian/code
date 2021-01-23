        public static byte[] PublicDecryption(this RSACryptoServiceProvider rsa, byte[] cipherData)
        {
            if (cipherData == null)
                throw new ArgumentNullException("cipherData");
            BigInteger numEncData = new BigInteger(cipherData);
            RSAParameters rsaParams = rsa.ExportParameters(false);
            BigInteger Exponent = new BigInteger(rsaParams.Exponent);
            BigInteger Modulus = new BigInteger(rsaParams.Modulus);
            BigInteger decData2 = numEncData.modPow(Exponent, Modulus);
            byte[] data = decData2.getBytes();
            bool first = false;
            List<byte> bl = new List<byte>();
            for (int i = 0; i < data.Length; ++i)
            {
                if (!first && data[i] == 0x00)
                {
                    first = true;
                }
                else if (first)
                {
                    if (data[i] == 0x00)
                    {
                        return bl.ToArray();
                    }
                    bl.Add(data[i]);
                }
            }
            if (bl.Count > 0)
                return bl.ToArray();
            return new byte[0];
        }
