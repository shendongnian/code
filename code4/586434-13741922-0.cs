    class RamDisk
    {
        public const string MountPoint = "X:";
        public void createRamDisk()
        {
            try
            {
                string initializeDisk   = "imdisk -a ";
                string imdiskSize       = "-s 1024M ";
                string mountPoint       = "-m "+ MountPoint + " ";
                
                ProcessStartInfo procStartInfo  = new ProcessStartInfo();
                procStartInfo.UseShellExecute   = false;
                procStartInfo.CreateNoWindow    = true;
                procStartInfo.FileName          = "cmd";
                procStartInfo.Arguments         = "/C " + initializeDisk + imdiskSize + mountPoint;
                Process.Start(procStartInfo);
                
                formatRAMDisk();
            }
            catch (Exception objException)
            {
                Console.WriteLine("There was an Error, while trying to create a ramdisk! Do you have imdisk installed?");
                Console.WriteLine(objException);
            }
        }
        /**
         * since the format option with imdisk doesn't seem to work
         * use the fomat X: command via cmd
         * 
         * as I would say in german:
         * "Von hinten durch die Brust ins Auge"
         * **/
        private void formatRAMDisk(){
            string cmdFormatHDD = "format " + MountPoint + "/Q /FS:NTFS";
            SecureString password = new SecureString();
            password.AppendChar('0');
            password.AppendChar('8');
            password.AppendChar('1');
            password.AppendChar('5');
            
            ProcessStartInfo formatRAMDiskProcess   = new ProcessStartInfo();
            formatRAMDiskProcess.UseShellExecute    = false;
            formatRAMDiskProcess.CreateNoWindow     = true;
            formatRAMDiskProcess.RedirectStandardInput     = true;
            formatRAMDiskProcess.FileName           = "cmd";
            formatRAMDiskProcess.Verb               = "runas";
            formatRAMDiskProcess.UserName           = "Administrator";
            formatRAMDiskProcess.Password           = password;
            formatRAMDiskProcess.Arguments          = "/C " + cmdFormatHDD;
            Process process                         = Process.Start(formatRAMDiskProcess);
            sendCMDInput(process);
        }
        private void sendCMDInput(Process process)
        {
            StreamWriter inputWriter = process.StandardInput;
            inputWriter.WriteLine("J");
            inputWriter.Flush();
            inputWriter.WriteLine("RAMDisk for valueable data");
            inputWriter.Flush();
        }
        public string getMountPoint()
        {
            return MountPoint;
        }
    }
