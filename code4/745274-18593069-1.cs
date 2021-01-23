		private void LoadDirectories(TreeListNode parent, DirectoryInfo directoryInfo)
		{
			DirectoryInfo[] directories = directoryInfo.GetDirectories();
			foreach (DirectoryInfo directory in directories)
			{
				if ((directory.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden) continue;
				TreeListNode child = new TreeListNode() { Tag = directory, Text = directory.Name };
				parent.Nodes.Add(child);
			}
			FileInfo[] files = directoryInfo.GetFiles();
			foreach (FileInfo file in files)
			{
				TreeListNode child = new TreeListNode() { Tag = file, Text = file.Name };
				parent.Nodes.Add(child);
			}
		}
