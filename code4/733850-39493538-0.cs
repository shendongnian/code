        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool SetVolumeLabel(string lpRootPathName, string lpVolumeName);
        public static void Main()
        {
            string name = "E:\\";
            var status = SetVolumeLabel(name, "Test");
            var error = Marshal.GetLastWin32Error();
            Console.WriteLine(status + " " + error);
        }
