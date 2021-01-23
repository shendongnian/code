    using System;
    using System.Text;
    using System.Runtime.InteropServices;
    public class Utils {
        public static bool IsNetAssembly(string path) {
            var sb = new StringBuilder(256);
            int written;
            var hr = GetFileVersion(path, sb, sb.Capacity, out written);
            return hr == 0;
        }
        [DllImport("mscoree.dll", CharSet = CharSet.Unicode)]
        private static extern int GetFileVersion(string path, StringBuilder buffer, int buflen, out int written);
    }
