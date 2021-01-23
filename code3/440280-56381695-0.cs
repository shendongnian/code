csharp
public List<DriveInfo> getExternalDrives()
{
    var drives = DriveInfo.GetDrives();
    var externalDrives = new List<DriveInfo>();
    var allPhysicalDisks = new ManagementObjectSearcher("select MediaType, DeviceID from Win32_DiskDrive").Get();
    foreach (var physicalDisk in allPhysicalDisks)
    {
        var allPartitionsOnPhysicalDisk = new ManagementObjectSearcher($"associators of {{Win32_DiskDrive.DeviceID='{physicalDisk["DeviceID"]}'}} where AssocClass = Win32_DiskDriveToDiskPartition").Get();
        foreach(var partition in allPartitionsOnPhysicalDisk)
        {
            if (partition == null)
                continue;
            var allLogicalDisksOnPartition = new ManagementObjectSearcher($"associators of {{Win32_DiskPartition.DeviceID='{partition["DeviceID"]}'}} where AssocClass = Win32_LogicalDiskToPartition").Get();
            foreach(var logicalDisk in allLogicalDisksOnPartition)
            {
                if (logicalDisk == null)
                    continue;
                var drive = drives.Where(x => x.Name.StartsWith(logicalDisk["Name"] as string, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                var mediaType = (physicalDisk["MediaType"] as string).ToLowerInvariant();
                if (mediaType.Contains("external") || mediaType.Contains("removable"))
                    externalDrives.Add(drive);
            }
        }
    }
    return externalDrives;
}
