     string backupFile = @"\\Fabtrol-2\Program Files (x86)\FabTrolBackUp\FT_Trans_Log_Appendedold.BAK";
     FileInfo fi = new FileInfo(backupFile);
     DateTime fileCreatedDate = File.GetCreationTime(backupFile);
     DateTime today = DateTime.Now;
     if (today.DayOfWeek != DayOfWeek.Monday && fileCreatedDate > today.AddDays(-2))
         {
            fi.Delete();
         }
                
