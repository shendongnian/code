	const string root = "<<your root path>>";
	const string directoryToLookFor = "<<the folder name you are looking for>>";
	foreach (var directory in Directory.EnumerateDirectories(root, "*.*", SearchOption.TopDirectoryOnly))
	{
		var foundDirectory = Directory.EnumerateDirectories(directory, directoryToLookFor, SearchOption.TopDirectoryOnly).FirstOrDefault();
		if (!String.IsNullOrEmpty(foundDirectory))
		{
			var filesInside = Directory.GetFiles(foundDirectory);
			foreach (var file in filesInside)
			{
				Console.WriteLine(file);
			}
		}
	}
