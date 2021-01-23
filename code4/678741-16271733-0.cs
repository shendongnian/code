    Response.Buffer = true;
    Response.Clear();
    Response.ContentType = "application/pdf";
    
    // if blob is the byte array of the pdf file
    Response.BinaryWrite(blob);  
    Response.Flush();
    Response.End();
