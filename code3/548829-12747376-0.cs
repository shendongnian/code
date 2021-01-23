    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    using Microsoft.Win32.SafeHandles;
     
    public static class LongPath
    {
        static class Win32Native
        {
            [StructLayout(LayoutKind.Sequential)]
            public class SECURITY_ATTRIBUTES
            {
                public int nLength;
                public IntPtr pSecurityDescriptor;
                public int bInheritHandle;
            }
     
            [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern bool CreateDirectory(string lpPathName, SECURITY_ATTRIBUTES lpSecurityAttributes);
     
            [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern SafeFileHandle CreateFile(string lpFileName, int dwDesiredAccess, FileShare dwShareMode, SECURITY_ATTRIBUTES securityAttrs, FileMode dwCreationDisposition, int dwFlagsAndAttributes, IntPtr hTemplateFile);
        }
     
        public static bool CreateDirectory(string path)
        {
            return Win32Native.CreateDirectory(String.Concat(@"\\?\", path), null);
        }
     
        public static FileStream Open(string path, FileMode mode, FileAccess access)
        {
            SafeFileHandle handle = Win32Native.CreateFile(String.Concat(@"\\?\", path), (int)0x10000000, FileShare.None, null, mode, (int)0x00000080, IntPtr.Zero);
            if (handle.IsInvalid)
            {
                throw new System.ComponentModel.Win32Exception();
            }
            return new FileStream(handle, access);
        }
    }
