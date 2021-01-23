	public bool getLatest(string[] items)
	{
		try
		{
			Workspace myWorkspace = createWorkspace();
			var results = myWorkspace.Get(items, VersionSpec.Latest, RecursionType.Full, GetOptions.Overwrite);
			var failures = results.GetFailures();
			foreach(var fail in failures)
			{
				Tools.MessageLogger.LogError(fail.GetFormattedMessage());
			}
			
			return failures.Count == 0;
		}
		catch (Exception ex)
		{
			Tools.MessageLogger.LogError(ex.Message);
			return false;
		}
	}
