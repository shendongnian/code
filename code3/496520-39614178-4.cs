    public static byte[] HmacSha512(string text, string key)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(text);
        var hmac = new Org.BouncyCastle.Crypto.Macs.HMac(new Org.BouncyCastle.Crypto.Digests.Sha512Digest());
        hmac.Init(new Org.BouncyCastle.Crypto.Parameters.KeyParameter(System.Text.Encoding.UTF8.GetBytes(key)));
        byte[] result = new byte[hmac.GetMacSize()];
        hmac.BlockUpdate(bytes, 0, bytes.Length);
        hmac.DoFinal(result, 0);
    
        return result;
    }
