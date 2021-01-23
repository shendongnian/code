    public static class Encryption
    {
    	public static string Encrypt(string prm_text_to_encrypt, string prm_key, string prm_iv)
    	{
    		var sToEncrypt = prm_text_to_encrypt;
    
    		var rj = new RijndaelManaged()
    		{
    			Padding = PaddingMode.PKCS7,
    			Mode = CipherMode.CBC,
    			KeySize = 256,
    			BlockSize = 256,
    		};
    
    		var key = Convert.FromBase64String(prm_key);
    		var IV = Convert.FromBase64String(prm_iv);
    
    		var encryptor = rj.CreateEncryptor(key, IV);
    
    		var msEncrypt = new MemoryStream();
    		var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
    
    		var toEncrypt = Encoding.ASCII.GetBytes(sToEncrypt);
    
    		csEncrypt.Write(toEncrypt, 0, toEncrypt.Length);
    		csEncrypt.FlushFinalBlock();
    
    		var encrypted = msEncrypt.ToArray();
    
    		return (Convert.ToBase64String(encrypted));
    		}
    
    	public static string Decrypt(string prm_text_to_decrypt, string prm_key, string prm_iv)
    	{
    
    		var sEncryptedString = prm_text_to_decrypt;
    
    		var rj = new RijndaelManaged()
    		{
    			Padding = PaddingMode.PKCS7,
    			Mode = CipherMode.CBC,
    			KeySize = 256,
    			BlockSize = 256,
    		};
    
    		var key = Convert.FromBase64String(prm_key);
    		var IV = Convert.FromBase64String(prm_iv);
    
    		var decryptor = rj.CreateDecryptor(key, IV);
    
    		var sEncrypted = Convert.FromBase64String(sEncryptedString);
    
    		var fromEncrypt = new byte[sEncrypted.Length];
    
    		var msDecrypt = new MemoryStream(sEncrypted);
    		var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
    
    		csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);
    
    		return (Encoding.ASCII.GetString(fromEncrypt));
    		}
    
    	public static void GenerateKeyIV(out string key, out string IV)
    	{
    		var rj = new RijndaelManaged()
    		{
    			Padding = PaddingMode.PKCS7,
    			Mode = CipherMode.CBC,
    			KeySize = 256,
    			BlockSize = 256,
    		};
    		rj.GenerateKey();
    		rj.GenerateIV();
    
    		key = Convert.ToBase64String(rj.Key);
    		IV = Convert.ToBase64String(rj.IV);
    	}
    }
