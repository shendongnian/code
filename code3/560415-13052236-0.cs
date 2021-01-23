	public void RecursivePathWalk(string directory)
	{
		string[] filePaths = Directory.GetFiles(directory);
		foreach (string filePath in filePaths)
		{
			if (IsSystem(filePath))
				continue;
			
			DoWork(filePath);
		}
		string[] subDirectories = Directory.GetDirectories(directory);
		foreach (string subDirectory in subDirectories)
		{
			if (IsSystem(subDirectory))
				continue;
			RecursivePathWalk(subDirectory);
		}
	}
	public void DoWork(string filePath)
	{
		//Your logic here
	}
	public bool IsSystem(string path)
	{
		FileAttributes attributes = File.GetAttributes(path);
		return (attributes & FileAttributes.System) != 0;
	}
