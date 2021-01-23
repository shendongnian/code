	public static Task WaitForFileAsync(string path)
	{
		return Task.Run(() =>
		{
			while (!File.Exists(path))
			{
			}
			return;
		});
	}
