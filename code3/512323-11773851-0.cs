    string salt = "AAAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA";
    string password = "AAAAAAAAA-BBBB-AAAA-AAAA-AAAAAAAAAAAA";
    string EncryptedValue(string data)
    {	
    byte[] saltBytes = System.Text.Encoding.UTF8.GetBytes(salt);
	string encryptedData = String.Empty;
	using (System.Security.Cryptography.AesManaged aes = new System.Security.Cryptography.AesManaged())
	{
		var rfc = new System.Security.Cryptography.Rfc2898DeriveBytes(password, saltBytes);
        aes.BlockSize = aes.LegalBlockSizes[0].MaxSize; 
        aes.KeySize = aes.LegalKeySizes[0].MaxSize; 
		aes.Key = rfc.GetBytes(32); 
		rfc.Reset(); 
		aes.IV = rfc.GetBytes(16);
	    // Create a decrytor to perform the stream transform.
	    System.Security.Cryptography.ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
	    // Create the streams used for encryption.
	    using (MemoryStream msEncrypt = new MemoryStream())
	    {
	        using (System.Security.Cryptography.CryptoStream csEncrypt = new System.Security.Cryptography.CryptoStream(msEncrypt, encryptor, System.Security.Cryptography.CryptoStreamMode.Write))
	        {
	            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
	            {
	                // Write all data to the stream.
	                swEncrypt.Write(data);
	            }
				
	            encryptedData = Convert.ToBase64String(msEncrypt.ToArray());
	        }
	    }
	}
	return encryptedData;
    }
