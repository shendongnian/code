    [SecuritySafeCritical]
    internal static string InternalCopy(string sourceFileName, string destFileName, bool overwrite, bool checkHost)
    {
        string fullPathInternal = Path.GetFullPathInternal(sourceFileName);
        string dst = Path.GetFullPathInternal(destFileName);
        new FileIOPermission(FileIOPermissionAccess.Read, new string[] { fullPathInternal }, false, false).Demand();
        new FileIOPermission(FileIOPermissionAccess.Write, new string[] { dst }, false, false).Demand();
        if (!Win32Native.CopyFile(fullPathInternal, dst, !overwrite))
        {
            int errorCode = Marshal.GetLastWin32Error();
            string maybeFullPath = destFileName;
            if (errorCode != 80)
            {
                using (SafeFileHandle handle = Win32Native.UnsafeCreateFile(fullPathInternal, -2147483648, FileShare.Read, null, FileMode.Open, 0, IntPtr.Zero))
                {
                    if (handle.IsInvalid)
                    {
                        maybeFullPath = sourceFileName;
                    }
                }
                if ((errorCode == 5) && Directory.InternalExists(dst))
                {
                    throw new IOException(Environment.GetResourceString("Arg_FileIsDirectory_Name", new object[] { destFileName }), 5, dst);
                }
            }
            __Error.WinIOError(errorCode, maybeFullPath);
        }
        return dst;
    }
 
 
