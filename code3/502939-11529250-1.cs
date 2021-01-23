	public static void RunSnippet()
	{
		OutputData(GetData());
	}
	
	public static MemoryStream GetData()
	{
		MemoryStream outputStream = new MemoryStream();
		using (MemoryStream ms = new MemoryStream())
		using (StreamWriter sw = new StreamWriter(ms))
		{
			string data = "My test data is really great!";
			
			sw.Write(data);
			sw.Flush();
			
			ms.WriteTo(outputStream);
			outputStream.Seek(0, SeekOrigin.Begin);
		}
		return outputStream;
	}
	
	public static void OutputData(MemoryStream inputStream)
	{
		using (StreamReader sr = new StreamReader(inputStream))
		{
			Console.WriteLine(sr.ReadToEnd());
		}
	}	
