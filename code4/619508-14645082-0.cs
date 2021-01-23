	string fileName = "D:\\newZIPfile.zip";
	Stream myStream = Request.InputStream;
	byte[] message = new byte[myStream.Length];
	myStream.Read(message, 0, (int)myStream.Length);
	
	using (FileStream fs = new FileStream(fileName, FileMode.Create))
	{
		using (BinaryWriter writer = new BinaryWriter(fs, System.Text.Encoding.UTF8))
		{
			writer.Write(message);
		}
	}
