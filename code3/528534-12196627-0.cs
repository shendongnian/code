    using System.Text;
    using System.Runtime.InteropServices;
    ...
        public static string Utf8PtrToString(IntPtr utf8) {
            int len = MultiByteToWideChar(65001, 0, utf8, -1, null, 0);
            if (len == 0) throw new System.ComponentModel.Win32Exception();
            var buf = new StringBuilder(len);
            len = MultiByteToWideChar(65001, 0, utf8, -1, buf, len);
            return buf.ToString();
        }
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int MultiByteToWideChar(int codepage, int flags, IntPtr utf8, int utf8len, StringBuilder buffer, int buflen);
