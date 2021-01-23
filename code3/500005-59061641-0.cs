    public static string GetMD5Hash(string text)
    {
        using ( var md5 = MD5.Create() )
        {
            byte[] computedHash = md5.ComputeHash( Encoding.UTF8.GetBytes(text) );
            return new System.Runtime.Remoting.Metadata.W3cXsd2001.SoapHexBinary(computedHash).ToString();
        }
    }
