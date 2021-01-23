    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.InteropServices;
    namespace Demo
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                var site = new byte[32,10];
                using (var fs = new FileStream("C:\\TEST\\TEST.BIN", FileMode.Create))
                {
                    FastWrite(fs, site, 0, 32*10);
                }
            }
            [DllImport("kernel32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool WriteFile
            (
                IntPtr hFile,
                IntPtr lpBuffer,
                uint nNumberOfBytesToWrite,
                out uint lpNumberOfBytesWritten,
                IntPtr lpOverlapped
            );
            public static void FastWrite<T>(FileStream fs, T[,] array, int offset, int count) where T : struct
            {
                int sizeOfT = Marshal.SizeOf(typeof (T));
                GCHandle gcHandle = GCHandle.Alloc(array, GCHandleType.Pinned);
                try
                {
                    uint bytesWritten;
                    uint bytesToWrite = (uint) (count*sizeOfT);
                    if (!WriteFile(
                        fs.SafeFileHandle.DangerousGetHandle(),
                        new IntPtr(gcHandle.AddrOfPinnedObject().ToInt64() + (offset*sizeOfT)),
                        bytesToWrite,
                        out bytesWritten,
                        IntPtr.Zero
                    )){
                        throw new IOException("Unable to write file.", new Win32Exception(Marshal.GetLastWin32Error()));
                    }
                    Debug.Assert(bytesWritten == bytesToWrite);
                }
                finally
                {
                    gcHandle.Free();
                }
            }
        }
    }
