    System.IO.DirectoryInfo di = new System.IO.DirectoryInfo("YourDirectoryPath");
    System.IO.FileInfo[] files = di.GetFiles();
    var sortedFiles = from f in files
                              orderby f.CreationTime ascending
                              select f;
