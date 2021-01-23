    byte[] GetEncryptionKey()
    {
    	var path = Path.Combine(
    		Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
    		AppDomain.CurrentDomain.FriendlyName,
    		"nothing interesting... move along",
    		"top secret encryption key").Dump();
    		
    	var file = new FileInfo(path);
    	if (!file.Directory.Exists)
    		file.Directory.Create();
    		
    	// determine if current user of machine
    	// or any user of machine can decrypt the key
    	var scope = DataProtectionScope.CurrentUser;
    	
    	// make it a bit tougher to decrypt 
    	var entropy = Encoding.UTF8.GetBytes("correct horse battery staple :)");
    	
    	if (file.Exists)
    	{
    		return ProtectedData.Unprotect(
    			File.ReadAllBytes(path), entropy, scope);		
    	}
    	
    	// generate key
    	byte[] key;
    	using(var rng = RNGCryptoServiceProvider.Create())
    		key = rng.GetBytes(1024);
    	
    	// encrypt the key
    	var encrypted = ProtectedData.Protect(key, entropy, scope);
    	
    	// save for later use	
    	File.WriteAllBytes(path, encrypted);
    		
    	return key;
    }
