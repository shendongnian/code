	private void clearFolderWithFilter(string folderName, string filesToExclude)
	{
		DirectoryInfo dir = new DirectoryInfo(folderName);
	
		foreach(FileInfo fi in dir.GetFiles())
		{
			if(!fi.Name.Contains(filesToExclude))
			{
				// System.Diagnostics.Debug.WriteLine("DELETING file " + fi + " because it does NOT contain '" + filesToExclude + "' ");
				fi.Delete();
			} else {
				// System.Diagnostics.Debug.WriteLine("SAVING file " + fi + " because it contains '" + filesToExclude + "' ");
			}
		}
	
		foreach (DirectoryInfo di in dir.GetDirectories())
		{
			if(!di.Name.Contains(filesToExclude))
			{
				// System.Diagnostics.Debug.WriteLine("DELETING directory " + di + " because it does NOT contain '" + filesToExclude + "' ");
				clearFolderWithFilter(di.FullName, filesToExclude);
				di.Delete();
			} else {
				// System.Diagnostics.Debug.WriteLine("SAVING directory " + di + " because it contains '" + filesToExclude + "' ");
			}
		}
	}
