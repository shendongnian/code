    class Caller
    {
        [DllImport("kernel32.dll")]
        private extern static IntPtr LoadLibrary(String path);
        [DllImport("kernel32.dll")]
        private extern static IntPtr GetProcAddress(IntPtr lib, String funcName);
        [DllImport("kernel32.dll")]
        private extern static bool FreeLibrary(IntPtr lib);
        private IntPtr _hModule;
        public Caller(string dllFile)
        {
            _hModule = LoadLibrary(dllFile);
        }
        ~Caller()
        {
            FreeLibrary(_hModule);
        }
        delegate string VersionFun();
        int main()
        {
            Caller caller = new Caller("abcdef.dll");
            IntPtr hFun = GetProcAddress(_hModule, "Version");
            VersionFun fun = Marshal.GetDelegateForFunctionPointer(hFun, typeof(VersionFun)) as VersionFun;
            Console.WriteLine(fun());
            return 0;
        }
    }
