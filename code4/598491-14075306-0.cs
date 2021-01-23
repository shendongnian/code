    public class Drive
    {
        private Lazy<string> nameOfDrive = new Lazy<string>(DriveName);
    
        public string NameOfDrive
        {
            get { return nameOfDrive.Value; }
        }
    
        private static string DriveName()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
    
            foreach (DriveInfo d in drives)
            {
                if (d.Name == @"C:")
                    return d.Name;
            }
    
            throw new Exception("Unable to locate the C: Drive... Please map the correct drive.");
        }
    }
