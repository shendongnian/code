    class ReadyDriveInfo
    {
        public string Name { get; set; }
        public string AvailableFreeSpace { get; set; }
    }
    public static List<ReadyDriveInfo> GetReadyDrives()
    {
        return DriveInfo.GetDrives()
            .Where(d => d.IsReady)
            .Select(d => new ReadyDriveInfo
                {
                    Name = d.Name,
                    AvailableFreeSpace = d.AvailableFreeSpace.ToString()
                })
            .ToList();
    }
