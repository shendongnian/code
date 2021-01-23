	public static void Main()
	{
		Directory.CreateDirectory("test");
		Directory.CreateDirectory("test2");
		File.WriteAllText(Path.Combine("test", Path.GetRandomFileName()), "test");
		var datapath = ".";
		
		var files = Directory.EnumerateFiles(datapath, "*", SearchOption.AllDirectories);
		files.Dump();
		
		var fileSystemEntries  = Directory.EnumerateFileSystemEntries(datapath, "*", SearchOption.AllDirectories);
		fileSystemEntries.Dump();
	}
