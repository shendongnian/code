     /// <summary>
     /// Returns recently written File from the specified directory.
     /// If the directory does not exist or doesn't contain any file, null is returned.
     /// </summary>
     /// <param name="directoryInfo">Path of the directory that needs to be scanned</param>
     /// <returns></returns>
     public static string NewestFileofDirectory(DirectoryInfo directoryInfo )
     {
        if (directoryInfo == null || !directoryInfo.Exists)
            return null;
        
         FileInfo[] files = directoryInfo.GetFiles();
         DateTime recentWrite = DateTime.MinValue;
         FileInfo recentFile = null;
        
         foreach (FileInfo file in files)
         {
             if (file.LastWriteTime > recentWrite)
             {
                recentWrite = file.LastWriteTime;
                recentFile = file;
             }
          }
             return recentFile.Name;
     }
