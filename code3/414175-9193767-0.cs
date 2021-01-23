    foreach (DirectoryInfo directory in directories)
    {
        foreach (FileInfo file in directory.GetFiles("*.csv"))
        {
            try
            {
                //do something with file
    
             }
    
             catch (Exception e)
             {
                   //catch exception
              }
         }
        
         foreach(FileInfo fileToDeleteInfo...)
         {
              try
              {
                   if (!IsFileLocked(fileToDeleteInfo))
                   {
                      string[] files = Directory.GetFiles(@"C:\Test");
                      foreach (string filetoDelete in files)
                      {
                           File.Delete(filetoDelete);
                      }
                    }
                        
                    
                }
              catch(...)
              {... }
         }
     
