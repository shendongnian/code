    Response.Clear();
    Response.ContentType = "Application/msword";
    Response.AddHeader("Content-Disposition", "attachment; filename=myfile.docx");
    
    //ADDED THIS LINE
    myMemoryStream.Seek(0,SeekOrigin.Begin);
    myMemoryStream.WriteTo(Response.OutputStream); 
    Response.Flush();
    Response.Close();
