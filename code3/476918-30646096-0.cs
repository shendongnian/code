    static class MyDll
    {
        static MyDll()
        {
            var is64 = IntPtr.Size == 8;
            LoadLibrary(is64 ? "win64/MyDll.dll" : "win32/MyDll.dll");
        }
        [DllImport("kernel32.dll")]
        private static extern IntPtr LoadLibrary(string dllToLoad);
        [DllImport("MyDll.dll")]
        public static extern int MyFunction(int var1, int var2);
    }
