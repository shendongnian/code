    using System.IO;
    using System.Management;
    
     DriveInfo[] dis = DriveInfo.GetDrives();
     foreach ( DriveInfo di in dis )
     {
         if ( di.DriveType == DriveType.Network )
         {
            //network drive
         }
      }
