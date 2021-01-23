    public static List<string[]> GetReadyDrives()
    {
        return DriveInfo.GetDrives()
            .Where(d => d.IsReady)
            .Select(d => new[] { d.Name, d.AvailableFreeSpace.ToString() })
            .ToList();
    }
