	byte[] idbyte = UnicodeEncoding.Default.GetBytes("b669fd8c904d48e0945c16cac1dc5ed9");
	FileStream input1 = new FileStream(@"C:\test1.xlsx", FileMode.Open, FileAccess.Read);
	FileStream output1 = new FileStream(@"C:\test2.xlsx", FileMode.OpenOrCreate, FileAccess.Write);
	int SizeOfBuffer = 1024 * 16;
	try
	{
		byte[] currentBuffer = new byte[SizeOfBuffer];
		byte[] nextBuffer = new byte[SizeOfBuffer];
		int currentRead;
		int nextRead;
		nextRead = input1.Read(nextBuffer, 0, nextBuffer.Length);
		while (nextRead > 0)
		{
			currentBuffer = nextBuffer;
			currentRead = nextRead;
			if ((nextRead = input1.Read(nextBuffer, 0, nextBuffer.Length)) > 0)
			{
				output1.Write(currentBuffer, 0, currentRead);
			}
			else   // delete id with byte[] 
			{
				byte[] buffer2 = new byte[currentRead - idbyte.Length];
				for (int i = 0; i < buffer2.Length; i++)
				{
					buffer2[i] = currentBuffer[i];
				}
				output1.Write(buffer2, 0, buffer2.Length);
				break;
			}
		}
	}
	catch (Exception ex)
	{
		Console.WriteLine(ex.ToString());
	}
	output1.Close();
	input1.Close();
	Console.ReadLine();
