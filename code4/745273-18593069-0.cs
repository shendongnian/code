		private void BeforeExpand(object sender, BeforeExpandEventArgs e)
		{
			TreeListNode current = e.Node;
			if (current.Nodes.Count > 0)
				return;
			if (current.Tag is DriveInfo)
			{
				exampleTree.BeginUpdate();
				DriveInfo driveInfo = current.Tag as DriveInfo;
				LoadDirectories(current, driveInfo.RootDirectory);
				exampleTree.EndUpdate(true);
			}
			else if (current.Tag is DirectoryInfo)
			{
				exampleTree.BeginUpdate();
				LoadDirectories(current, (DirectoryInfo)current.Tag);
				exampleTree.EndUpdate(true);
			}
		}
