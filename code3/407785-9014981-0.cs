	public static string Cipher(object obj)
	{
		string j = JSON(obj);
		using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
		{
			aesAlg.Key = System.Text.Encoding.UTF8.GetBytes("salt");
			aesAlg.IV = System.Text.Encoding.UTF8.GetBytes("salt");
			ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
			// Create the streams used for encryption.
			using (MemoryStream msEncrypt = new MemoryStream())
			{
				using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
				{
					using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
					{
						swEncrypt.Write(j);
					}
					byte[] encrypted = msEncrypt.ToArray();
					return Convert.ToBase64String(encrypted).Replace('/', '-').Replace('+', '_').Replace("=", "");
				}
			}
		}
	}
