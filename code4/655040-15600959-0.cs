		var timer = new System.Threading.Timer(CheckProcesses);
		timer.Change(TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(1));
		//...
		timer.Dispose();
	private void CheckProcesses(object state)
	{
		Process[] Procesy = Process.GetProcesses();
		foreach (Process Proces in Procesy)
		{
			List<BlaclistedProcess> blacklist = (from p in CurrentBlacklist.Processes
												 where p.ProcessName == Proces.ProcessName
												 select p).ToList<BlaclistedProcess>();
			if (blacklist.Count == 1)
			{
				Proces.Kill();
			}
		}
	}
