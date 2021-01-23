	public void InsertWave(string mainFile, string insertFile, long position)
	{
		byte[] data = File.ReadAllBytes(insertFile);
		using (FileStream main = File.OpenWrite(mainFile))
		{
			main.Seek(position, SeekOrigin.Begin);
			main.Write(data, 0, data.Length);
			main.Close();
		}
	}
