    public static IEnumerable<DriveInfo> GetReadyDrives()
    {
        return DriveInfo.GetDrives()
            .Where(d => d.IsReady);
    }
