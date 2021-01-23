    private void fileUsage()
     {
       String tmpPath = "C:\\Tes";
       FileInfo newestFile = GetNewestFile(new DirectoryInfo(tmpPath));
         if (newestFile != null)
            {
              int lastmodifiedDate = newestFile.LastAccessTime.Millisecond;
              if (lastmodifiedDate <= 604800000)
                 {
                   Console.WriteLine("The File " + newestFile.Name + " has been used at " + newestFile.LastAccessTime.ToLocalTime());
                  }
            }
    
     }
    private FileInfo GetNewestFile(DirectoryInfo directoryInfo)
    {
       var myFile = (from f in directoryInfo.GetFiles()
                              orderby f.LastWriteTime descending
                              select f).First();
    
       return new FileInfo(myFile.FullName);
    }
