    static class MyDll
    {
        static MyDll()
        {            
            var myPath = new Uri(typeof(MyDll).Assembly.CodeBase).LocalPath;
            var myFolder = Path.GetDirectoryName(myPath);
            var is64 = IntPtr.Size == 8;
            var subfolder = is64 ? "\\win64\\" : "\\win32\\";
            LoadLibrary(myFolder + subfolder + "MyDll.dll");
        }
        [DllImport("kernel32.dll")]
        private static extern IntPtr LoadLibrary(string dllToLoad);
        [DllImport("MyDll.dll")]
        public static extern int MyFunction(int var1, int var2);
    }
