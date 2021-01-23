    [SecuritySafeCritical]
    public static void Delete(string path)
    {
        if (path == null)
        {
            throw new ArgumentNullException("path");
        }
        string fullPathInternal = Path.GetFullPathInternal(path);
        new FileIOPermission(FileIOPermissionAccess.Write, new string[] { fullPathInternal }, false, false).Demand();
        if (!Win32Native.DeleteFile(fullPathInternal))
        {
            int errorCode = Marshal.GetLastWin32Error();
            if (errorCode != 2)
            {
                __Error.WinIOError(errorCode, fullPathInternal);
            }
        }
    }
    
     
