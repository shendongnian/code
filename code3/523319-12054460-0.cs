    DriveInfo[] drives = DriveInfo.GetDrives(); 
     
    foreach (DriveInfo d in drives) 
    { 
       MessageBox.Show(d.Name);
       string volumeLabel = null;
       try
       {
         volumeLabel = d.VolumeLabel;
       }
       catch (Exception ex)
       {
         if (ex is IOException || ex is UnauthorizedAccessException || ex is SecurityException)
           MessageBox.Show(ex.Message);
         else
           throw;
       }
       if (volumeLabel != null && volumeLabel.Contains(drivename)) 
       { 
          MessageBox.Show("Got Ya"); 
          sDir = d.Name; 
          break; 
       } 
    } 
