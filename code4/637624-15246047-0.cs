	public static string GetBranchName(string path, string prefix)
	{
		string folder = Path.GetDirectoryName(path);
	
		// Walk up the path until it ends with Dev\Branches
		while (!String.IsNullOrEmpty(folder) && folder.Contains(prefix))
		{
			string parent = Path.GetDirectoryName(folder);
			if (parent != null && parent.EndsWith(prefix))
				return Path.GetFileName(folder);
	
			folder = parent;
		}
	
		return null;
	}
