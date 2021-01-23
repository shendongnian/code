    class Program
    {
        static void Main(string[] args)
        {
            string companyName = "Example Company?*, Inc.";
            //Example Company Inc
            var sanitizedName = sanitize(companyName);
            //create the directory
            Directory.CreateDirectory(sanitizedName);
            //create the name store
            var nameStreamPath = sanitizedName + ":Name";
            writeFileContent(companyName, nameStreamPath);
            //try to return the name
            Console.WriteLine(getFileContent(nameStreamPath));
            Console.ReadLine();
        }
        private static string getFileContent(string path)
        {
            using (var sr = new StreamReader(new FileStream(
                // we have to call CreateFile directly to avoid overzealous path validation
                NativeMethods.CreateFileOrFail(path, false), FileAccess.Read)))
            {
                return sr.ReadToEnd();
            }
        }
        private static void writeFileContent(string companyName, string path)
        {
            using (var sw = new StreamWriter(new FileStream(
                // we have to call CreateFile directly to avoid overzealous path validation
                NativeMethods.CreateFileOrFail(path, true), FileAccess.Write)))
            {
                sw.Write(companyName);
            }
        }
        private static string sanitize(string path)
        {
            char[] newPath = new char[path.Length];
            int newPathLoc = 0;
            for (int i = 0; i < path.Length; i++)
            {
                if (char.IsLetter(path[i]) || char.IsDigit(path[i]))
                {
                    newPath[newPathLoc] = path[i];
                    newPathLoc++;
                }
            }
            return new string(newPath, 0, newPathLoc);
        }
    }
    class NativeMethods
    {
        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern SafeFileHandle CreateFile(
            string fileName,
            [MarshalAs(UnmanagedType.U4)] FileAccess fileAccess,
            [MarshalAs(UnmanagedType.U4)] FileShare fileShare,
            IntPtr securityAttributes,
            [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition,
            [MarshalAs(UnmanagedType.U4)] FileAttributes flags,
            IntPtr template);
        public static SafeFileHandle CreateFileOrFail(string path, bool write)
        {
            var handle = CreateFile(path,
                write ? FileAccess.Write : FileAccess.Read,
                write ? FileShare.None : FileShare.Read,
                IntPtr.Zero,
                write ? FileMode.Create : FileMode.Open,
                FileAttributes.Normal,
                IntPtr.Zero);
            if (handle.IsInvalid)
                throw new System.ComponentModel.Win32Exception();
            return handle;
        }
    }
