    class TrueCryptHelp
    {
        // I have that program on the working directory
        // it can be downloaded from http://technet.microsoft.com/en-us/sysinternals/bb896655.aspx
        const string HandleExeLocation = "handle.exe"; 
        static string systemProcessFiles;
        static DateTime dateFilesLockedInfo = new DateTime();
        static string SystemProcessFiles
        {
            get
            {
                if ((DateTime.Now - dateFilesLockedInfo).TotalSeconds > 2)
                {
                    Process p = new Process();
                    var psi = new ProcessStartInfo();
                    psi.RedirectStandardOutput = true;
                    psi.UseShellExecute = false;
                    psi.FileName = HandleExeLocation;
                    p.StartInfo = psi;
                    p.Start();
                    var output = p.StandardOutput.ReadToEnd();
                    systemProcessFiles = string.Empty;
                    foreach (Match m in Regex.Matches(output ?? "", @"(?sx) -{20}  [^-]  .+?  -{20}"))
                    {
                        if (Regex.Match(m.Value ?? "", @"(?xi) -{10}  [\s\r\n]+  System \s pid").Success)
                        {
                            if (Regex.Match(m.Value ?? "", @"(?xi)  \) \s+ \\clfs \s* (\r|\n)").Success)
                            {
                                systemProcessFiles = m.Value.ToLower();
                                break;
                            }
                        }
                    }
                }
                dateFilesLockedInfo = DateTime.Now;
                return systemProcessFiles;
            }
        }
        public static bool IsVolumeMounted(string volumeLocation)
        {
            //DriveInfo d = new System.IO.DriveInfo(volume.DriveLetter);
            //if (d == null)
            //return false;
            //if (d.DriveType != System.IO.DriveType.Fixed)
            //return false;
            //if ((d.DriveFormat ?? "").ToLower().Contains("fat") == false)
            //return false;
            if (SystemProcessFiles.Contains(volumeLocation.ToLower()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
