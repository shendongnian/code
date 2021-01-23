    void Main()
    {
    
      if (Drive.AcquireCDrive() == null)
          throw new Exception("Unable to locate the C: Drive... Please map the correct drive.");
    
    }
    
    public class Drive
    {
        public static DriveInfo AcquireCDrive()
        {
           return DriveInfo.GetDrives()
                           .OfType<DriveInfo>()
                           .Where (drive => drive.IsReady)
                           .FirstOrDefault( drive => drive.Name.Contains(@"C:"));
        }
    } 
