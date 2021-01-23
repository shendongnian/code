	/// <summary>Synchronizes the date time to ntp server using w32time service</summary>
	/// <returns><c>true</c> if [command succeed]; otherwise, <c>false</c>.</returns>
	public static bool SyncDateTime()
	{
		try
		{
			ServiceController serviceController = new ServiceController("w32time");
			if (serviceController.Status != ServiceControllerStatus.Running)
			{
				serviceController.Start();
			}
			Logger.TraceInformation("w32time service is running");
			Process netTime = new Process();
			Process pTime = new Process();
			pTime.StartInfo.FileName = "w32tm";
			pTime.StartInfo.Arguments = "/resync";
			pTime.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			pTime.Start();
			pTime.WaitForExit();
			Logger.TraceInformation("w32time service has sync local dateTime from NTP server");
			return true;
		}
		catch (Exception exception)
		{
			Logger.LogError("unable to sync date time from NTP server", exception);
			return false;
		}
	}
