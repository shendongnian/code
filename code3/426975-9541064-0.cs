	public static bool DeleteDirectories(string root)
	{
		bool removed = false;
	
		var dirs = new Stack<string>();
		var emptyDirs = new Dictionary<string, int>();
	
		if (!System.IO.Directory.Exists(root))
		{
			throw new ArgumentException();
		}
		dirs.Push(root);
	
		while (dirs.Count > 0)
		{
			string currentDir = dirs.Pop();
	
			string[] subDirs;
			try
			{
				subDirs = System.IO.Directory.GetDirectories(currentDir);
			}
			catch (UnauthorizedAccessException e)
			{
				Console.WriteLine(e.Message);
				continue;
			}
			catch (System.IO.DirectoryNotFoundException e)
			{
				Console.WriteLine(e.Message);
				continue;
			}
	
			if (Directory.GetFiles(currentDir).Length == 0)
			{
				emptyDirs.Add(currentDir, subDirs.Length); // add directory path and number of sub directories
			}
	
			// Push the subdirectories onto the stack for traversal.
			foreach (string str in subDirs)
				dirs.Push(str);
		}
	
		var reversedEmptyDirs = emptyDirs.Reverse();
	
		foreach (var dir in reversedEmptyDirs)
		{	
			if (emptyDirs[dir.Key] == 0) // delete if 0 subdirectories
			{
				string parentDir = Directory.GetParent(dir.Key).FullName;
				Console.WriteLine(dir.Key); // comment this line
				//Directory.Delete(dir.Key); // uncomment this line to delete
				if (emptyDirs.ContainsKey(parentDir))
				{
					emptyDirs[parentDir]--; // decrement number of subdirectories of parent
				}
				removed = true;
			}
		}
	
		return removed;
	}
