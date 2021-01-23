    using System.Runtime.InteropServices;
    class C
    {
        [DllImport("user32.dll")]
        public static extern int MessageBoxA(int h, string m, string c, int type);
        public static int Main()
        {
            return MessageBoxA(0, "Hello World!", "Caption", 0);
        }
    }
