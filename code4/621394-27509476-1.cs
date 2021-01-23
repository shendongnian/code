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
			Process processTime = new Process();
			processTime.StartInfo.FileName = "w32tm";
			processTime.StartInfo.Arguments = "/resync";
			processTime.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			processTime.Start();
			processTime.WaitForExit();
			Logger.TraceInformation("w32time service has sync local dateTime from NTP server");
			return true;
		}
		catch (Exception exception)
		{
			Logger.LogError("unable to sync date time from NTP server", exception);
			return false;
		}
	}
