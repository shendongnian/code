    [DllImport("ScanDll.dll", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Ansi)]
    private static extern ImageAndScanError GetMicrInfo(StringBuilder cMicrInfo, out int iInfoLength);
    public String GetMicrInfo()
    {
        StringBuilder info = new StringBuilder(96);
        int length;
        ImageAndScanError error = GetMicrInfo(info, out length);
        if (error != ImageAndScanError.ErrorNone) throw new Exception(String.Format("GetMicrInfo error: {0}", error));
        return info.ToString();
    }
