    public struct DRIVER_INFO_2
    {
        public uint cVersion;
        [MarshalAs(UnmanagedType.LPTStr)] public string pName;
        [MarshalAs(UnmanagedType.LPTStr)] public string pEnvironment;
        [MarshalAs(UnmanagedType.LPTStr)] public string pDriverPath;
        [MarshalAs(UnmanagedType.LPTStr)] public string pDataFile;
        [MarshalAs(UnmanagedType.LPTStr)] public string pConfigFile;
    }
    public static class EnumeratePrinterDriverNames
    {
        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int EnumPrinterDrivers(String pName, String pEnvironment, uint level, IntPtr pDriverInfo,
            uint cdBuf, ref uint pcbNeeded, ref uint pcRetruned);
        public static IEnumerable<string> Enumerate()
        {
            const int ERROR_INSUFFICIENT_BUFFER = 122;
            uint needed = 0;
            uint returned = 0;
            if (EnumPrinterDrivers(null, null, 2, IntPtr.Zero, 0, ref needed, ref returned) != 0)
            {
                //succeeds, but shouldn't, because buffer is zero (too small)!
                throw new ApplicationException("EnumPrinters should fail!");
            }
            int lastWin32Error = Marshal.GetLastWin32Error();
            if (lastWin32Error != ERROR_INSUFFICIENT_BUFFER)
            {
                throw new Win32Exception(lastWin32Error);
            }
            IntPtr address = Marshal.AllocHGlobal((IntPtr) needed);
            try
            {
                if (EnumPrinterDrivers(null, null, 2, address, needed, ref needed, ref returned) == 0)
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }
                var type = typeof (DRIVER_INFO_2);
                IntPtr offset = address;
                int increment = Marshal.SizeOf(type);
                for (uint i = 0; i < returned; i++)
                {
                    var di = (DRIVER_INFO_2) Marshal.PtrToStructure(offset, type);
                    offset += increment;
                    yield return di.pName;
                }
            }
            finally
            {
                Marshal.FreeHGlobal(address);
            }
        }
    }
