        [System.Security.SuppressUnmanagedCodeSecurity, System.Runtime.InteropServices.DllImport("kernel32.dll")]
        static extern void GetSystemTimePreciseAsFileTime(out FileTime pFileTime);
        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct FileTime  {
            public const long FILETIME_TO_DATETIMETICKS = 504911232000000000;   // 146097 = days in 400 year Gregorian calendar cycle. 504911232000000000 = 4 * 146097 * 86400 * 1E7
            public uint TimeLow;    // least significant digits
            public uint TimeHigh;   // most sifnificant digits
            public long TimeStamp_FileTimeTicks { get { return TimeHigh * 4294967296 + TimeLow; } }     // ticks since 1-Jan-1601 (1 tick = 100 nanosecs). 4294967296 = 2^32
            public DateTime dateTime { get { return new DateTime(TimeStamp_FileTimeTicks + FILETIME_TO_DATETIMETICKS); } }
        }
        public static DateTime GetTimeStamp() { 
            FileTime ft; GetSystemTimePreciseAsFileTime(out ft);
            return ft.dateTime;
        }
