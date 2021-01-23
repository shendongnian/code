    ResourcesManager.GetResourceFromExecutable(assembly.ManifestModule.FullyQualifiedName, "PACKAGES.TXT", ResourcesManager.RT_RCDATA);
    public static class ResourcesManager
    {
        public const uint RT_RCDATA = 0x10;
        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibraryEx(string lpFileName, IntPtr hFile, uint dwFlags);
        [DllImport("Kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr LoadLibrary(string lpFileName);
        [DllImport("kernel32.dll")]
        public static extern IntPtr FindResource(IntPtr hModule, string lpName, uint lpType);
        //  public static extern IntPtr FindResource(IntPtr hModule, int lpName, uint lpType);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr LoadResource(IntPtr hModule, IntPtr hResInfo);
        [DllImport("kernel32.dll")]
        public static extern IntPtr LockResource(IntPtr hResData);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern uint SizeofResource(IntPtr hModule, IntPtr hResInfo);
        public static string GetResourceFromExecutable(string lpFileName, string lpName, uint lpType)
        {
            IntPtr hModule = LoadLibrary(lpFileName);
            if (hModule != IntPtr.Zero)
            {
                IntPtr hResource = FindResource(hModule, lpName, lpType);
                if (hResource != IntPtr.Zero)
                {
                    uint resSize = SizeofResource(hModule, hResource);
                    IntPtr resData = LoadResource(hModule, hResource);
                    if (resData != IntPtr.Zero)
                    {
                        byte[] uiBytes = new byte[resSize];
                        IntPtr ipMemorySource = LockResource(resData);
                        Marshal.Copy(ipMemorySource, uiBytes, 0, (int)resSize);
                        //....
                    }
                }
            }
        }
    }
}
