    public static bool AssemblyExist(string assemblyname, out string response)
    {
        try
        {
            response = QueryAssemblyInfo(assemblyname);
            return true;
        }
        catch (System.IO.FileNotFoundException e)
        {
            response = e.Message;
            return false;
        }
    }
    // If assemblyName is not fully qualified, a random matching may be 
    public static String QueryAssemblyInfo(string assemblyName)
    {
        var assembyInfo = new AssemblyInfo {cchBuf = 512};
        assembyInfo.currentAssemblyPath = new String('', assembyInfo.cchBuf);
        IAssemblyCache assemblyCache;
        // Get IAssemblyCache pointer
        var hr = GacApi.CreateAssemblyCache(out assemblyCache, 0);
        if (hr == IntPtr.Zero)
        {
            hr = assemblyCache.QueryAssemblyInfo(1, assemblyName, ref assembyInfo);
            if (hr != IntPtr.Zero)
            {
                Marshal.ThrowExceptionForHR(hr.ToInt32());
            }
        }
        else
        {
            Marshal.ThrowExceptionForHR(hr.ToInt32());
        }
        return assembyInfo.currentAssemblyPath;
    }
