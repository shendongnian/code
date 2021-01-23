	private string GetDriveLetter(string volumeLabel)
	{
		string driveLetter = "";
		DriveInfo[] dis = DriveInfo.GetDrives();
		foreach (DriveInfo di in dis)
		{
			var dt = di.DriveType;
			if (dt == DriveType.Fixed || dt == DriveType.Removable)
			{
				if (di.VolumeLabel == volumeLabel)
				{
					driveLetter = di.Name.Substring(0, 1).ToUpper();
					break;
				}
			}
		}
		return driveLetter;
	}
