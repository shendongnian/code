    string tmp = Path.GetTempFileName();
    using(Stream s = new FileStream(filePath,
        FileMode.Open, FileAccess.Read,
        // following option will let you open
        // opened file by other process
        FileShare.ReadWrite)){
    
       using(FileStream fs = File.OpenWrite(tmp)){
          // this will copy file to tmp
          s.CopyTo(fs);
       }
    
    }
    
    // upload  tmp  file...
