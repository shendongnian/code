    //Connect to your file
    FileStream sourceFile = new FileStream(Server.MapPath(@"FileName"), FileMode.Open);
    float FileSize= sourceFile.Length;
    
    //Write the file content to a byte Array 
    byte[] getContent = new byte[(int)FileSize];
    sourceFile.Read(getContent, 0, (int)sourceFile.Length);
    sourceFile.Close();
    
    //Build HTTP Response object
    Response.ContentType = "application/octet-stream";
    Response.AddHeader("Content-Length", getContent.Length.ToString());
    Response.AddHeader("Content-Disposition", "attachment; filename=" + FileName);
    Response.BinaryWrite(getContent);
    Response.Flush();
    Response.End();
