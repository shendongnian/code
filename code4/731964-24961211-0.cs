        void Main()
        {
        	GetServicePackVersion().Major.Dump();
        }
        [StructLayout(LayoutKind.Sequential)]
        private struct OSVERSIONINFOEX
        {
            public int dwOSVersionInfoSize;
            public int dwMajorVersion;
            public int dwMinorVersion;
            public int dwBuildNumber;
            public int dwPlatformId;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128 )]
            public string szCSDVersion;
            public short wServicePackMajor;
            public short wServicePackMinor;
            public short wSuiteMask;
            public byte wProductType;
            public byte wReserved;
        }
        [DllImport("kernel32.dll")]
        private static extern bool GetVersionEx([In, Out] ref OSVERSIONINFOEX osVersionInfo);
        public static Version GetServicePackVersion()
        {
            OSVERSIONINFOEX osVersionInfo = new OSVERSIONINFOEX();
            osVersionInfo.dwOSVersionInfoSize = Marshal.SizeOf(typeof(OSVERSIONINFOEX));
            if (GetVersionEx(ref osVersionInfo))
            {
                Version result = new Version(osVersionInfo.wServicePackMajor, osVersionInfo.wServicePackMinor);
                return result;
            }
            else
            {
                return null;
            }
        }
