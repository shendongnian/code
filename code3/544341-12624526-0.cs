    public static void Encode(string path)
    {
    	byte[] bytes;
    	using (var sr = new StreamReader(path))
    	{
    		var text = sr.ReadToEnd();
    		bytes = Encoding.UTF8.GetBytes(text);
    	}
    	using (var sw = new StreamWriter(path))
    	{
    		foreach (byte b in bytes)
    		{
    			sw.WriteLine(b);
    		}
    	}
    }
    
    public static void Decode(string path)
    {
    	var data = new List<byte>();
    	using (var sr = new StreamReader(path))
    	{
    		string line;
    		while((line = sr.ReadLine()) != null)
    			data.Add(Byte.Parse(line));
    	}
    	using (var sw = new StreamWriter(path))
    	{
    		sw.Write(Encoding.UTF8.GetString(data.ToArray()));
    	}
    }
