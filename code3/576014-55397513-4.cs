	public static void Main()
	{
		Directory.CreateDirectory("dir");
		Directory.CreateDirectory("dir2");
		File.WriteAllText(Path.Combine("dir", Path.GetRandomFileName()), "file");
		var datapath = ".";
		
		var files = Directory.EnumerateFiles(datapath, "*", SearchOption.AllDirectories);
		files.Dump();
		
		var fileSystemEntries  = Directory.EnumerateFileSystemEntries(datapath, "*", SearchOption.AllDirectories);
		fileSystemEntries.Dump();
	}
