    using System;
    using System.Runtime.InteropServices;
    
    [StructLayout(LayoutKind.Sequential)]
    struct SYSTEMTIME
    {
        [MarshalAs(UnmanagedType.U2)] public short Year;
        [MarshalAs(UnmanagedType.U2)] public short Month;
        [MarshalAs(UnmanagedType.U2)] public short DayOfWeek;
        [MarshalAs(UnmanagedType.U2)] public short Day;
        [MarshalAs(UnmanagedType.U2)] public short Hour;
        [MarshalAs(UnmanagedType.U2)] public short Minute;
        [MarshalAs(UnmanagedType.U2)] public short Second;
        [MarshalAs(UnmanagedType.U2)] public short Milliseconds;
    }
    
    class Test
    {
        [DllImport("kernel32.dll")]
        public extern static uint SetSystemTime(ref SYSTEMTIME lpSystemTime);
        
        static void Main()
        {
            SYSTEMTIME st = new SYSTEMTIME();
            st.Year = 2009;
            st.Month = 1;
            st.Day = 1;
            st.Hour = 23;
            st.Minute = 1;
            st.Second = 1;
            SetSystemTime(ref st);
       } 
    }
