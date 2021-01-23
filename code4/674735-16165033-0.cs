    foreach (DriveInfo drive in DriveInfo.GetDrives())
     {
         if (drive.DriveType == DriveType.Removable)
         {
            cmbUSB.Items.Add(drive.Name + "-" + drive.VolumeLabel);
                                               //^^^^^^^^^^^^^^^^
                                               //here   
         }
     }
    
