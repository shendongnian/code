	public static void Main(string[ args)
	{
		TarInputStream tarIn = new TarInputStream(new FileStream(@args[0], FileMode.Open, FileAccess.Read));
		TarEntry curEntry = tarIn.GetNextEntry();
		while (curEntry != null)
		{
			if (curEntry.Name.EndsWith("foo.txt", StringComparison.CurrentCultureIgnoreCase))
			{
                //create a type of byte dynamic array 
				byte[] outBuffer = new byte[curEntry.Size];
				FileStream fs = new FileStream(@"foo.txt", FileMode.Create, FileAccess.Write);
				BinaryWriter bw = new BinaryWriter(fs);
				tarIn.Read(outBuffer, 0, (int)curEntry.Size);
				bw.Write(outBuffer,0,outBuffer.Length);
				bw.Close();
			}
			curEntry = tarIn.GetNextEntry();
		}
		tarIn.Close();
	}
