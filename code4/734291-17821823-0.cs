    public string GetFileHash(string filename)
    {
    	var hash = new SHA1Managed();
    	var clearBytes = File.ReadAllBytes(filename);
    	var hashedBytes = hash.ComputeHash(clearBytes);
    	return ConvertBytesToHex(hashedBytes);
    }
    public string ConvertBytesToHex(byte[] bytes)
    {
        var sb = new StringBuilder();
    
    	for(var i=0; i<bytes.Length; i++)
    	{
    	    sb.Append(bytes[i].ToString("x"));
    	}
    	return sb.ToString();
    }
    [Test]
    public void CompareTwoFiles()
    {
        const string originalFile = @"path_to_file";
        const string copiedFile = @"path_to_file";
    
    	var originalHash = GetFileHash(originalFile);
    	var copiedHash = GetFileHash(copiedFile);
    
    	Assert.AreEqual(copiedHash, originalHash);
    }
