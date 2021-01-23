    Response.AddHeader("Content-Disposition", "attachment; filename=" + oldfilename);
    Response.ContentType = "text/plain";
    
    Response.BinaryWrite(fileContents);   //byte array contents of file
    Response.End();
