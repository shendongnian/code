    foreach (DriveInfo drive in DriveInfo.GetDrives())
     {
         if (drive.DriveType == DriveType.Removable)
         {
            if (drive.IsReady)
                     cmbUSB.Items.Add(drive.Name + "-" + drive.VolumeLabel);
                                                         //^^^^^^^^^^^^^^^^
                                                         //here   
         }
     }
    
