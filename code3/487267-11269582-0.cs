    [DllImport("kernel32.dll", SetLastError = true)]
    static extern bool GetDiskFreeSpaceEx(
        string lpDirectoryName,
        out ulong lpFreeBytesAvailable,
        out ulong lpTotalNumberOfBytes,
        out ulong lpTotalNumberOfFreeBytes);
    static void TestDiskSpace()
    {
        IStorageFolder appFolder = ApplicationData.Current.LocalFolder;
        ulong a, b, c;
        if(GetDiskFreeSpaceEx(appFolder.Path, out a, out b, out c))
            Debug.WriteLine(string.Format("{0} bytes free", a));
    }
