    using System;
    using System.Runtime.InteropServices;
    class PlatformInvokeTest
    {
        //First param is of course either in your PATH, or an absolute path:
        [DllImport("msvcrt.dll", EntryPoint="puts", CallingConvention=CallingConvention.Cdecl)]
        public static extern int PutString(string c);
        [DllImport("msvcrt.dll", CallingConvention=CallingConvention.Cdecl)]
        internal static extern int _flushall();
        public static void Main() 
        {
            PutString("Test");
            _flushall();
        }
    }
