	foreach(Process p in Process.GetProcesses())
	{
		IntPtr buffer;
		uint bytesReturned;
		WTSQuerySessionInformation(WTS_CURRENT_SERVER_HANDLE, (uint) p.SessionId, WTS_INFO_CLASS.WTSWinStationName, out buffer, out bytesReturned);
		var sessionName = Marshal.PtrToStringAnsi(buffer);
		WTSFreeMemory(buffer);
		string moduleName = p.ProcessName;
		try
		{
			moduleName = p.Modules[0].ModuleName;
		}
		catch(Exception ex)
		{
			ex = ex;
		}
		Console.WriteLine(String.Format("{0,-17} {1,5} {2,-16} {3,12} {4,12} K", moduleName, p.Id, sessionName, p.SessionId, (p.WorkingSet64 / 1024).ToString("n0")));
	}
