    void OpenOrCreateFile()
    {
      try
       {
         string filePath = GetFilePath();
         EnsureFolder(filePath); //if directory not exist create it
         using(var fs = new FileStream(filePath, FileMode.OpenOrCreate))
           {
              //your code
           }
    
       }
       catch(Exception ex)
       {
         //handle exception   
       }
    }
        
    void EnsureFolder(string path)
    {
        string directoryName = Path.GetDirectoryName(path);
        if ((directoryName.Length > 0) && (!Directory.Exists(directoryName))
        {
            Directory.CreateDirectory(directoryName);
        }
    }
