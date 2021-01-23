    private void DownloadZipFileDialogue(string strZipFilePath)
    {
      Response.ContentType = "application/octet-stream";
      Response.AppendHeader("Content-Disposition", "attachment; filename=" +   Path.GetFileName(strZipFilePath));
    
        using(Stream input = File.OpenRead(strZipFilePath)){
           /// .NET 4.0, use following line if its .NET 4 project
           input.CopyTo(Response.OutputStream);
        
           /// .NET 2.0, use following lines if its .NET 2 project
           byte[] buffer = new byte[4096];
           int count = input.Read(buffer,0,buffer.Length);
           while(count > 0){
              Response.OutputStream.Write(buffer,0,count);
              count = input.Read(buffer,0,buffer.Length);
           }
        }
        
        File.Delete(strZipFilePath);
    }
