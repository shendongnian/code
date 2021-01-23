        static void Main(string[] args)
        {
            //if (args.GetLength(0) != 1)
            //{
            //    Debug.Assert(false);
            //    Console.WriteLine("You must supply the target file path");
            //    Environment.Exit(1);
            //}
            //String strTargetPath = args[0];
            String strTargetPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\MyCompany\MappedDrives.csv";
            FileStream fs = new FileStream(strTargetPath, FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(fs);
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo dInfo in allDrives)
            {
                if (dInfo.DriveType == DriveType.Network || dInfo.DriveType == DriveType.Removable)
                {
                    String s = String.Format("{0},{1},{2},{3},{4}\n", dInfo.Name, dInfo.VolumeLabel, dInfo.DriveType, dInfo.TotalSize, dInfo.AvailableFreeSpace);
                    writer.Write(s);
                }
            }
            writer.Close();
        }
