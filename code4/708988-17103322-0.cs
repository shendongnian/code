    <%
    try
    {
       System.String filename = "myFile.txt";
    
       // set the http content type to "APPLICATION/OCTET-STREAM
       Response.ContentType = "APPLICATION/OCTET-STREAM";
       
       // initialize the http content-disposition header to
       // indicate a file attachment with the default filename
       // "myFile.txt"
       System.String disHeader = "Attachment; Filename=\"" + filename +
          "\"";
       Response.AppendHeader("Content-Disposition", disHeader);
    
       // transfer the file byte-by-byte to the response object
       System.IO.FileInfo fileToDownload = new
          System.IO.FileInfo("C:\\downloadJSP\\DownloadConv\\myFile.txt");
       Response.Flush();
       Response.WriteFile(fileToDownload.FullName);}
    catch (System.Exception e)
    // file IO errors
    {
       SupportClass.WriteStackTrace(e, Console.Error);
    }
    %>
