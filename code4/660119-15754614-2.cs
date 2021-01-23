    This example shows you how to use the DllImport attribute to output a message by calling puts from msvcrt.dll.
    
    // PInvokeTest.cs
    using System;
    using System.Runtime.InteropServices;
    
    class PlatformInvokeTest
    {
        [DllImport("msvcrt.dll")]
        public static extern int puts(string c);
        [DllImport("msvcrt.dll")]
        internal static extern int _flushall();
    
        public static void Main() 
        {
            puts("Test");
            _flushall();
        }
    }
