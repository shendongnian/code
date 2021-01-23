           [DllImport("kernel32.dll", CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.StdCall,
            SetLastError = true)]
                public static extern SafeFileHandle CreateFile(
                    string lpFileName,
                    uint dwDesiredAccess,
                    uint dwShareMode,
                    IntPtr SecurityAttributes,
                    uint dwCreationDisposition,
                    uint dwFlagsAndAttributes,
                    IntPtr hTemplateFile
                );
        private static uint READ_CONTROL = 0x00020000;
        private static uint OPEN_EXISTING = 3;
        private static uint FILE_FLAG_BACKUP_SEMANTICS = 0x02000000;
            var file = @"myfile";
            File.Open(file,
                      FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            using(PrivilegeEnabler pe = new PrivilegeEnabler(Process.GetCurrentProcess(), Privilege.Backup))
            {
                var hFile = CreateFile(file,           // lpFileName
                           READ_CONTROL,               // dwDesiredAccess
                           0,                          // dwShareMode
                           IntPtr.Zero,                // lpSecurityAttributes
                           OPEN_EXISTING,              // dwCreationDisposition
                           FILE_FLAG_BACKUP_SEMANTICS, // dwFlagsAndAttributes
                           IntPtr.Zero);               // hTemplateFile
                using (var fs=new  FileStream(hFile.DangerousGetHandle(),FileAccess.Read))
                {
                    using (StreamReader rdr=new StreamReader(fs))
                    {
                        rdr.ReadToEnd();
                    }
                }
            }
