	static bool Compare(string filePath1, string filePath2)
	{
		using (FileStream file = File.OpenRead(filePath1))
		{
			using (FileStream file2 = File.OpenRead(filePath2))
			{
				if (file.Length != file2.Length)
				{
					return false;
				}
				const int size = 0x100000;
				var buffer = new byte[size];
				var buffer2 = new byte[size];
				while (file.Read(buffer, 0, buffer.Length) > 0)
				{
					file2.Read(buffer2, 0, buffer2.Length);
                        for (int i = 0; i < buffer.Length; i++)
                        {
                            if (buffer[i] != buffer2[i])
                            {
                                return false;
                            }
                        }
				}
			}
		}
		return true;
	}
