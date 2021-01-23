	/// <summary>
	/// Loads the history for a file
	/// </summary>
	/// <param name="filePath">Path to file</param>
	/// <returns>List of version history</returns>
	public List<IVersionHistory> LoadHistory(string filePath)
	{
		LibGit2Sharp.Repository repo = new Repository(this.pathToRepo);
		string path = filePath.Replace(this.pathToRepo.Replace(System.IO.Path.DirectorySeparatorChar + ".git", string.Empty), string.Empty).Substring(1);
		List<IVersionHistory> list = new List<IVersionHistory>();
		foreach (Commit commit in repo.Head.Commits)
		{
			if (this.TreeContainsFile(commit.Tree, path) && list.Count(x => x.Date == commit.Author.When) == 0)
			{
				list.Add(new GitCommit() { Author = commit.Author.Name, Date = commit.Author.When, Message = commit.MessageShort} as IVersionHistory);
			}
		}
		return list;
	}
	/// <summary>
	/// Checks a GIT tree to see if a file exists
	/// </summary>
	/// <param name="tree">The GIT tree</param>
	/// <param name="filename">The file name</param>
	/// <returns>true if file exists</returns>
	private bool TreeContainsFile(Tree tree, string filename)
	{
		if (tree.Any(x => x.Path == filename))
		{
			return true;
		}
		else
		{
			foreach (Tree branch in tree.Where(x => x.Type == GitObjectType.Tree).Select(x => x.Target as Tree))
			{
				if (this.TreeContainsFile(branch, filename))
				{
					return true;
				}
			}
		}
		return false;
	}
