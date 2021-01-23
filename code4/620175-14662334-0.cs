    static void DirSearch(string sDir, FtpConnection ftp)
    {
      try
      {
         // First, copy all files in the current directory
         foreach (string f in Directory.GetFiles(d))
         {
           Uri uri = new Uri(f);            
           ftp.PutFile(f, System.IO.Path.GetFileName(uri.LocalPath));
         }
        // For all directories in the current directory, create directory if there is
        // no such, and call this function recursively to copy files.
        
        foreach (string d in Directory.GetDirectories(sDir))
        {
          string dirname = new DirectoryInfo(d).Name;
          if (!ftp.DirectoryExists(dirname))
          {
            ftp.CreateDirectory(dirname);
          }
          ftp.SetCurrentDirectory(dirname);
          DirSearch(d, ftp);
        }
      
        
      }
      catch (System.Exception e)
      {
        MessageBox.Show(String.Format("Błąd FTP: {0} {1}", e.Message), "Błąd wysyłania plików na FTP", MessageBoxButton.OK, MessageBoxImage.Error);
      }
      finally{
         // Go back! 
         ftp.SetCurrentDirectory(".."); //untested, but it should be fine, as I don't see cdup command in ftplib
      }
    }
