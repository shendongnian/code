    void Main()
    {
    	Guid.NewGuid().Dump();
    	ParseCustom("ID123456").Dump();
    	ParseCustom("ID12345678").Dump();
    }
    
    private static Guid ParseCustom(string input)
    {
    	var md5 = System.Security.Cryptography.MD5.Create();
    	byte[] hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
    	var guidString = ToHexString(hashBytes);
    	return new Guid(guidString);
    }
    
    // Define other methods and classes here
    private static char ToHexDigit(int i)
    {
    	if (i < 10)
    		return (char)(i + '0');
    	return (char)(i - 10 + 'A');
    }
    
    public static string ToHexString(byte[] bytes)
    {
    	var chars = new char[bytes.Length * 2];
    
    	for (int i = 0; i < bytes.Length; i++)
    	{
    		chars[2 * i] = ToHexDigit(bytes[i] / 16);
    		chars[2 * i + 1] = ToHexDigit(bytes[i] % 16);
    	}
    	
    	var guid = new string(chars)
    		.Insert(8, "-")
    		.Insert(13, "-")
    		.Insert(18, "-")
    		.Insert(23, "-");
    	return guid.ToLower();
    }
