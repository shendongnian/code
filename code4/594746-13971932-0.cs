	public bool getLatest(string[] items)
	{
		try
		{
			Workspace myWorkspace = createWorkspace();
			
			var results = myWorkspace.Get(items, VersionSpec.Latest, RecursionType.Full, GetOptions.Overwrite);
			var failures = results.GetFailures();
			
			if(failures.Count > 0)
			{
				foreach(var fail in failures)
				{
					Tools.MessageLogger.LogError(fail.GetFormattedMessage());
				}
				
				return false;
			}
			else
			{
				return true;
			}
		}
		catch (Exception ex)
		{
			Tools.MessageLogger.LogError(ex.Message);
			return false;
		}
	}
