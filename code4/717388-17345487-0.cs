    public string GetMd5Hex(MD5 crypt, string input)
    {
    	return crypt.ComputeHash(UTF8Encoding.UTF8.GetBytes(input))
    		.Select<byte, string>(a => a.ToString("x2"))
    		.Aggregate<string>((a, b) => string.Format("{0}{1}", a, b));
    }
