	public void NewFolder(string path)
	{
		try
		{
			string name = @"\New Folder";
			string current = name;
			int i = 0;
			while (Directory.Exists(path + current))
			{
				i++;
				current = String.Format("{0} {1}", name, i);
			}
			//Directory.CreateDirectory(path + current);
			DirectorySecurity securityRules = new DirectorySecurity();
			securityRules.AddAccessRule(new FileSystemAccessRule(@"Domain\AdminAccount1", FileSystemRights.Read, AccessControlType.Allow));
			securityRules.AddAccessRule(new FileSystemAccessRule(@"Domain\YourAppAllowedGroup", FileSystemRights.FullControl, AccessControlType.Allow));
			DirectoryInfo di = Directory.CreateDirectory(path + current, securityRules);
	
			Explore(path); //this line is to refresh the items in the client side after creating the new folder
		}
		catch (Exception e)
		{
			sendInfo(e.Message, "error");
		}
	}
