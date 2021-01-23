    FileInfo fileInfo = new FileInfo(yourFilePath);    
    context.Response.Clear();   
    context.Response.ContentType = contentType;   //Set the contentType
    context.Response.AddHeader("content-disposition", "attachment; filename=" + Path.GetFilename(yourFilePath));   
    context.Response.AddHeader("Content-Length", fileInfo.Length.ToString());       
    context.Response.TransmitFile(yourFilePath); 
