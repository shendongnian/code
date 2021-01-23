    public static byte[] SHA512(string text)
    {
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(text);
        Org.BouncyCastle.Crypto.Digests.Sha512Digest digester = new Org.BouncyCastle.Crypto.Digests.Sha512Digest();
        byte[] retValue = new byte[digester.GetDigestSize()];
        digester.BlockUpdate(bytes, 0, bytes.Length);
        digester.DoFinal(retValue, 0);
        return retValue;
    }
