    System.IO.FileInfo[] fInfo = new System.IO.DirectoryInfo("YOUR_PATH").GetFiles();
      
    var filList = (from f in fInfo
               orderby f.CreationTime descending 
               select new
               {
                 FileName = f.Name,
                 UploadedDate = f.CreationTime,
                 Extension = f.Extension,
                 LastDownloadedDate = f.LastAccessTime //Not sure this would be the same.
               }).ToList();
