    private static RijndaelManaged BuildRigndaelCommon(out byte[] rgbIV, out byte[] key)
    {
    	rgbIV = new byte[] { 0x0, 0x1, 0x2, 0x3, 0x5, 0x6, 0x7, 0x8, 0xA, 0xB, 0xC, 0xD, 0xF, 0x10, 0x11, 0x12 };	
    	key = new byte[] { 0x0, 0x1, 0x2, 0x3, 0x5, 0x6, 0x7, 0x8, 0xA, 0xB, 0xC, 0xD, 0xF, 0x10, 0x11, 0x12 };
    	
    	//Specify the algorithms key & IV
    	RijndaelManaged rijndael = new RijndaelManaged{BlockSize = 128, IV = rgbIV, KeySize = 128, Key = key, Padding = PaddingMode.PKCS7 };	
    	return rijndael;
    }
    
    public static string Encrypt(string plaintext)
    {
    	byte[] rgbIV;
    	byte[] key;
    	
    	RijndaelManaged rijndael = BuildRigndaelCommon(out rgbIV, out key);
    	
    	//convert plaintext into a byte array
    	byte[] plaintextBytes = Encoding.UTF8.GetBytes(plaintext);
    	
    	byte[] cipherTextBytes = null;
    	
    	//create uninitialized Rijndael encryption obj
    	using (RijndaelManaged symmetricKey = new RijndaelManaged())
    	{
    		//Call SymmetricAlgorithm.CreateEncryptor to create the Encryptor obj
    		var transform = rijndael.CreateEncryptor();
    		
    		//Chaining mode
    		symmetricKey.Mode = CipherMode.CFB;		
    		//create encryptor from the key and the IV value
    		ICryptoTransform encryptor = symmetricKey.CreateEncryptor(key, rgbIV);
    		
    		//define memory stream to hold encrypted data
    		using (MemoryStream ms = new MemoryStream())
    		using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
    		{
    			//encrypt contents of cryptostream
    			cs.Write(plaintextBytes, 0, plaintextBytes.Length);
    			cs.Flush();
    			cs.FlushFinalBlock();
    			
    			//convert encrypted data from a memory stream into a byte array
    			ms.Position = 0;
    			cipherTextBytes = ms.ToArray();
    			
    			ms.Close();
    			cs.Close();
    		}
    	}
    	
    	//store result as a hex value
    	return BitConverter.ToString(cipherTextBytes).Replace("-", "");
    }
    
    public static string Decrypt(string disguisedtext)
    {
    	byte[] disguishedtextBytes = FromHexString(disguisedtext);
    
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
    	   
           //create encryptor from the key and the IV value
    
           // ICryptoTransform encryptor = symmetricKey.CreateEncryptor(key, rgbIV);
           ICryptoTransform decryptor = symmetricKey.CreateDecryptor(key, rgbIV);
    
           //define memory stream to hold encrypted data
           using (MemoryStream ms = new MemoryStream(disguishedtextBytes))
           {
               //define cryptographic stream - contains the transformation to be used and the mode
               using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
               {
    				byte[] decryptedData = new byte[disguishedtextBytes.Length];
    				int stringSize = cs.Read(decryptedData, 0, disguishedtextBytes.Length);
    				cs.Close();
    				
    					//Trim the excess empty elements from the array and convert back to a string
    				byte[] trimmedData = new byte[stringSize];
    				Array.Copy(decryptedData, trimmedData, stringSize);				
    				visiabletext = Encoding.UTF8.GetString(trimmedData);
               }
           }
       }
       return visiabletext;
    }
