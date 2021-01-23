	using (MemoryStream ms = new MemoryStream())
	{
		using (FileStream fs = File.OpenRead("C:\\t\\hello.txt"))
		{
			fs.CopyTo(ms);
			byte[] results = ms.GetBuffer();
			Console.WriteLine("Size: {0}", results.Length); // 256
			byte[] justdata = new byte[ms.Length];
			Array.Copy(results, justdata, ms.Length);
			Console.WriteLine("Size: {0}", justdata.Length); // 5
		}
	}
