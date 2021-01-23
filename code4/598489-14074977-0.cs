    public class Drive
    {
        private string nameOfDrive = null;
    
        public string NameOfDrive
        {
            get 
            {
                if (nameOfDrive == null)
                    nameOfDrive = DriveName();
                return nameOfDrive; 
            }
        }
    
        public Drive()
        {    }
        
        private string DriveName()
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
