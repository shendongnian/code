    public string SysInfo() 
    {
        Stringbuilder systemInformation = new Stringbuilder(string.Empty);
        systemInformation.AppendFormat("Operation System:  {0}\n", Environment.OSVersion);
        systemInformation.AppendFormat("ProcessorCount:  {0}\n", Environment.ProcessorCount);
        systemInformation.AppendFormat("SystemDirectory:  {0}\n", Environment.SystemDirectory);
        systemInformation.AppendFormat("UserDomainName:  {0}\n", Environment.UserDomainName);
        systemInformation.AppendFormat("UserName: {0}\n", Environment.UserName);
        foreach (System.IO.DriveInfo drive in System.IO.DriveInfo.GetDrives())
        {
            // Get each drive
            systemInformation.AppendFormat("\t Drive: {0}" +
                      "\n\t\t VolumeLabel: {1}" + 
                      "\n\t\t DriveType: {2}" +
                      "\n\t\t DriveFormat: {3}" +
                      "\n\t\t TotalSize: {4}" +
                      "\n\t\t AvailableFreeSpace: {5}\n",
                      DriveInfo1.Name, DriveInfo1.VolumeLabel, DriveInfo1.DriveType, 
                      DriveInfo1.DriveFormat, DriveInfo1.TotalSize, DriveInfo1.AvailableFreeSpace);
        }
        return systemInformation.ToString();
    }
