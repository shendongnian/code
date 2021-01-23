    public string getSHA256(string input)
    {
    	try
    	{
    		return BitConverter.ToString(SHA256Managed.Create().ComputeHash(Encoding.Default.GetBytes(input))).Replace(“-”, “”).ToLower();
    	}
    	catch (Exception e)
    	{
    		return string.Empty;
    	}
    }
