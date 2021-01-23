	public static void Main()
	{
		OutputData(GetData());
	}
	
	public static byte[] GetData()
	{
		byte[] binaryData = null;
		using (MemoryStream ms = new MemoryStream())
		using (StreamWriter sw = new StreamWriter(ms))
		{
			string data = "My test data is really great!";
			
			sw.Write(data);
			sw.Flush();
			
			binaryData = ms.ToArray();
		}
		
		return binaryData;
	}
	
	public static void OutputData(byte[] binaryData)
	{
		using (MemoryStream ms = new MemoryStream(binaryData))
		using (StreamReader sr = new StreamReader(ms))
		{
			Console.WriteLine(sr.ReadToEnd());
		}
	}
