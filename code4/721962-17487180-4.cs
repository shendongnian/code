    public static string Decrypt(string disguisedtext)
    {
        byte[] disguishedtextBytes = FromHexString(disguisedtext);
    	
    	var originalLength = disguishedtextBytes.Length;
    	
    	int BlockSize;
    	BlockSize = 16 * (1 + (originalLength / 16));
    	Array.Resize(ref disguishedtextBytes, BlockSize);
    	
    	// fill the remaining space with 0
    	for (int i = originalLength; i < BlockSize; i++)
    	{
    		disguishedtextBytes[i] = 0;
    	}
    	
    	
    	byte[] rgbIV;
    	byte[] key;
    	
    	BuildRigndaelCommon(out rgbIV, out key);	
    	
    	string visiabletext = "";
    	//create uninitialized Rijndael encryption obj
    	using (var symmetricKey = new RijndaelManaged())
    	{
    			//Call SymmetricAlgorithm.CreateEncryptor to create the Encryptor obj
    		symmetricKey.Mode = CipherMode.CFB;
    		symmetricKey.BlockSize = 128;
    		symmetricKey.Padding = PaddingMode.None;		
    					
    			// ICryptoTransform encryptor = symmetricKey.CreateEncryptor(key, rgbIV);
    		ICryptoTransform decryptor = symmetricKey.CreateDecryptor(key, rgbIV);
    		
    			//define memory stream to hold encrypted data
    		using (MemoryStream ms = new MemoryStream(disguishedtextBytes))
    		using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
    		{
    			byte[] decryptedData = new byte[disguishedtextBytes.Length];
    			int stringSize = cs.Read(decryptedData, 0, disguishedtextBytes.Length);
    			cs.Close();
    			
    				//Trim the excess empty elements from the array and convert back to a string
    			byte[] trimmedData = new byte[stringSize];
    			Array.Copy(decryptedData, trimmedData, originalLength); 
    			Array.Resize(ref trimmedData, originalLength);
    			
    			visiabletext = Encoding.UTF8.GetString(trimmedData);		
    		}
    	}
    	return visiabletext;
    }
