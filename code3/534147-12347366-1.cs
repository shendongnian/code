    var ddcPaths = new List<string>();
    var filePaths = new List<List<string>>();
    
    foreach (var directoryInfo in new DirectoryInfo(@"C:\Program Files\Logic\").GetDirectories())
    {
       if (directoryInfo.Name.Contains("DDC["))
       {
           ddcPaths.Add(directoryInfo.Name);
           var tempList = new List<string>();
           foreach (var fileInfo in directoryInfo.GetFiles())
           {
               tempList.Add(fileInfo.FullName);
           }
           filePaths.Add(tempList);
        }
    }
