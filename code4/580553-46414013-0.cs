     public FileExistence checkFileExists(string folder, string fileName)
        {
          //get file list
          List<SftpFile> fileList = sftp.ListDirectory(folder).ToList();
    
          if (fileList == null)
          {
            return FileExistence.UNCONFIRMED;
          }
    
          foreach (SftpFile f in fileList)
          {
            Console.WriteLine(f.ToString());
            //a not case sensitive comparison is made
            if (f.IsRegularFile && f.Name.ToLower() == fileName.ToLower())
            {
              return FileExistence.EXISTS;
            }
          }
    
          //if not found in traversal , it does not exist
          return FileExistence.DOES_NOT_EXIST;
        }
