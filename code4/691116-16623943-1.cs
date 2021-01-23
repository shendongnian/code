    using System;
    using System.Runtime.InteropServices;
    namespace ConsoleApplication1
    {
        public sealed class Fibonacci : IDisposable
        {
            #region DLL imports
            [DllImport("HSdll.dll", CallingConvention=CallingConvention.Cdecl)]
            private static extern unsafe void hs_init(IntPtr argc, IntPtr argv);
            [DllImport("HSdll.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern unsafe void hs_exit();
            [DllImport("HSdll.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern UInt32 c_fibonacci(byte i);
            #endregion
            #region Public interface
            public Fibonacci()
            {
                Console.WriteLine("Initialising DLL...");
                unsafe { hs_init(IntPtr.Zero, IntPtr.Zero); }
            }
            public void Dispose()
            {
                Console.WriteLine("Shutting down DLL...");
                unsafe { hs_exit(); }
            }
            public UInt32 fibonacci(byte i)
            {
                Console.WriteLine(string.Format("Calling c_fibonacci({0})...", i));
                var result = c_fibonacci(i);
                Console.WriteLine(string.Format("Result = {0}", result));
                return result;
            }
            #endregion
        }
    }
