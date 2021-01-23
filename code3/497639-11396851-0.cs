	using (Stream stream = new FileStream(@"D:\carry on baggage.PNG", FileMode.Create, FileAccess.ReadWrite))
	{
		// Buffer for reading data
		Byte[] bytes = new Byte[1024];
		int length;
		while ((length = networkStream.Read(bytes, 0, bytes.Length)) != 0)
		{
			stream.Write(bytes, 0, length);
		}
	}
