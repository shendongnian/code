    		[TestMethod]
    		public void EncryptIntsToInts()
    		{    
    			byte[] key =     "2b7e151628aed2a6abf7158809cf4f3c".HEX2Bytes();
    			byte[] test =    "6bc1bee22e409f96e93d7e117393172a".HEX2Bytes();
    			byte[] answer =  "3ad77bb40d7a3660a89ecaf32466ef97".HEX2Bytes();
    
    			var r = AES.Encrypt(test, key);
    
    			Assert.IsTrue(answer.SequenceEqual(r));
    		}
	public static byte[] Encrypt(byte[] input, byte[] key)
	{
		var aesAlg = new AesManaged
			             {
							 KeySize = 128,
							 Key = key,
							 BlockSize = 128,
							 Mode = CipherMode.ECB,
							 Padding = PaddingMode.Zeros,
							 IV = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
						 };
		ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
		return encryptor.TransformFinalBlock(input, 0, input.Length);
	}
