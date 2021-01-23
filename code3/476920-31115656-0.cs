    using System;
    using System.Runtime.InteropServices;
    using System.Reflection;
    using System.IO;
    class Program {
        static void Main(string[] args) {
            var path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            path = Path.Combine(path, IntPtr.Size == 8 ? "x64" : "x86");
            bool ok = SetDllDirectory(path);
            if (!ok) throw new System.ComponentModel.Win32Exception();
        }
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool SetDllDirectory(string path);
    }
