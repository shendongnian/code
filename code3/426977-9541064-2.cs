	public static bool DeleteDirectories(string root)
	{
		bool removed = false;
		var dirs = new Stack<string>();
		var emptyDirStack = new Stack<string>();
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
				emptyDirStack.Push(currentDir);
				emptyDirs.Add(currentDir, subDirs.Length); // add directory path and number of sub directories
			}
			// Push the subdirectories onto the stack for traversal.
			foreach (string str in subDirs)
				dirs.Push(str);
		}
		while (emptyDirStack.Count > 0)
		{	
			string currentDir = emptyDirStack.Pop();
			if (emptyDirs[currentDir] == 0)
			{
				string parentDir = Directory.GetParent(currentDir).FullName;
				Console.WriteLine(currentDir); // comment this line
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
