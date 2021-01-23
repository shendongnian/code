    string plaintext;
    byte[] Key = Convert.FromBase64String("Ii7oSjjWuhp6J6/hj/wmivqx1h3N2HzJ2ByJOy1n89E=");
    string encryptedbase64Password = "hRVlbM79aEQi8Tz7JJIL7CEhSxZAJvCh8Ni6ORP1C55+qbJzjDshBYBjyP12/zT2";
    byte[] IV = new byte[16];
    byte[] phase = Convert.FromBase64String(encryptedbase64Password);
    Array.Copy(phase, 0, IV, 0, IV.Length);
    byte[] cipherText = new byte[phase.Length - 16];;
    Array.Copy(phase, 16, cipherText, 0, cipherText.Length);
    
    using (AesManaged aesAlg = new AesManaged())
    {
    	aesAlg.KeySize = 256;
    	aesAlg.Mode = CipherMode.CBC;
    	aesAlg.Padding = PaddingMode.PKCS7;
    	aesAlg.Key = Key;
    	aesAlg.IV = IV;
    	// Create a decryptor to perform the stream transform.
        // NOTE: This is the difference between my original solution and the correct one.
    	ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
    	// Create the streams used for decryption.
    	using (MemoryStream msDecrypt = new MemoryStream(cipherText))
    	{
    		using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
    		{
    			using (StreamReader srDecrypt = new StreamReader(csDecrypt))
    			{
    				// Read the decrypted bytes from the decrypting stream and place them in a string.
    				plaintext = srDecrypt.ReadToEnd();
    			}
    		}
    	}
    }
