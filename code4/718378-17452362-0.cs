	private string GetAvailableUsbDrive()
	{
		foreach (var info in System.IO.DriveInfo.GetDrives())
		{
			if (info.DriveType == System.IO.DriveType.Removable && 
				 info.IsReady && 
				!info.Name.Equals("A:\\"))
			{
				return info.Name;
			}
		}
		return string.Empty;
	}
