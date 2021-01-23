    public String AES_encrypt(String Input)
    {
    	var aes = new RijndaelManaged();
    	aes.KeySize = 256;
    	aes.BlockSize = 256;
    	aes.Padding = PaddingMode.PKCS7;
    	aes.Key = Convert.FromBase64String("yourkey");//your key
    	aes.IV = Convert.FromBase64String("youriv");//your iv
    	var encrypt = aes.CreateEncryptor(aes.Key, aes.IV);
    	byte[] xBuff = null;
    	using (var ms = new MemoryStream())
    	{
    		using (var cs = new CryptoStream(ms, encrypt, CryptoStreamMode.Write))
    		{
    			byte[] xXml = Encoding.UTF8.GetBytes(Input);
    			cs.Write(xXml, 0, xXml.Length);
    		}
    		xBuff = ms.ToArray();
    	}
    	String Output = Convert.ToBase64String(xBuff);
    	return Output;
    }
        
    public String AES_decrypt(String Input)
    {
    	RijndaelManaged aes = new RijndaelManaged();
    	aes.KeySize = 256;
    	aes.BlockSize = 256;
    	aes.Mode = CipherMode.CBC;
    	aes.Padding = PaddingMode.PKCS7;
    	aes.Key = Convert.FromBase64String("yourkey");//your key
    	aes.IV = Convert.FromBase64String("youriv");//your iv
    	var decrypt = aes.CreateDecryptor();
    	byte[] xBuff = null;
    	using (var ms = new MemoryStream())
    	{
    		using (var cs = new CryptoStream(ms, decrypt, CryptoStreamMode.Write))
    		{
    			byte[] xXml = Convert.FromBase64String(Input);
    			cs.Write(xXml, 0, xXml.Length);
    		}
    		xBuff = ms.ToArray();
    	}
    	String Output = Encoding.UTF8.GetString(xBuff);
    	return Output;
    }
