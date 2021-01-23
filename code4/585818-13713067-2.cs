    public string FileContents
    {
        get { 
           using (var fs = new FileStream(FullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
           using (var rdr = new StreamReader(fs))
           {
              return rdr.ReadToEnd();
           }
        }
    }
