    using System;
    using System.Runtime.InteropServices;
    class Program
    {
        [DllImport("msvcrt.dll")]
        public static extern int puts([MarshalAs(UnmanagedType.LPStr)] string m);
        [DllImport("msvcrt.dll")]
        internal static extern int _flushall();
    
        public static void Main() 
        {
            puts("Hello World!");
            _flushall();
        }
    }
