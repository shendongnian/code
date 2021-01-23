    FileInfo file = new FileInfo(Path.Combine(localFolder, filename));
    int len = (int)file.Length, bytes;
    Response.ContentType = "text/plain"; //Set the file type here
    Response.AddHeader "Content-Disposition", "attachment;filename=" + filename; 
    context.Response.AppendHeader("content-length", len.ToString());
    byte[] buffer = new byte[1024];
    
    using(Stream stream = File.OpenRead(path)) {
        while (len > 0 && (bytes =
            stream.Read(buffer, 0, buffer.Length)) > 0)
        {
            Response.OutputStream.Write(buffer, 0, bytes);
            len -= bytes;
        }
    }
