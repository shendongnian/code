    private static void EncryptData(string data, Stream stream)
    {
        if (stream.CanWrite == false)
                throw new IOException("Cannot write to stream.");
        var bytes = Encoding.UTF8.GetBytes(data);
        var encryptedBytes = ProtectedData.Protect(bytes, null, DataProtectionScope.CurrentUser);
        stream.Write(encryptedBytes , 0, encryptedBytes .Length);
    }
    private static string DecryptData(Stream stream)
    {
	    if (stream.CanRead == false)
                throw new IOException("Cannot read fromstream.");
		
		using (MemoryStream memoryStream = new MemoryStream())
		{
			stream.CopyTo(memoryStream);
			var encryptedBytes = memoryStream.ToArray();
			var decryptedBytes = ProtectedData.Unprotect(encryptedBytes, null, DataProtectionScope.CurrentUser)
			return Encoding.UTF8.GetString(decryptedBytes);
		}
    }
	
