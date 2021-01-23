	public static void Encrypt(string password)
	{
		using (var fileStream = new FileStream(@"MyFile.dat", FileMode.Create))
		{
			EncryptData(password, fileStream);
			fileStream.Close();
		}
	}
	
	public static string Decrypt()
	{
		string password;
		using (var fileStream = new FileStream(@"MyFile.dat", FileMode.Open))
		{
			password = DecryptData(fileStream);
			fileStream.Close();
		}
		return password;
	}
	
