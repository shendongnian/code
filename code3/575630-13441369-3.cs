    public static byte[] EncryptPart(ICryptoTransform crypt, byte[] toEncrypt)
    {
        try
        {
            MemoryStream mStream = new MemoryStream();
            CryptoStream cStream = new CryptoStream(mStream,
                crypt,
                CryptoStreamMode.Write);
            cStream.Write(toEncrypt, 0, toEncrypt.Length);
            cStream.FlushFinalBlock();
            byte[] ret = mStream.ToArray();
            cStream.Close();
            mStream.Close();
            Console.WriteLine("DES OUTPUT : " + ByteArrayToString(ret));
            return ret;
        }
        catch (CryptographicException e)
        {
            Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
            return null;
        }
    }
