	private void urlShortcutToFolder(string linkName, string linkUrl)
	{
		//string deskDir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
		//using (StreamWriter writer = new StreamWriter(deskDir + "\\" + linkName + ".url"))
		string nonSystemDir = @"C:\Downloads";
		if(!System.IO.Directory.Exists(nonSystemDir))
		{
			throw New Exception("Path " + nonSystemDir + " is not valid");
		}
		using (StreamWriter writer = new StreamWriter(nonSystemDir + "\\" + linkName + ".url"))
		{
			writer.WriteLine("[InternetShortcut]");
			writer.WriteLine("URL=" + linkUrl);
			writer.Flush();
		}
	}
