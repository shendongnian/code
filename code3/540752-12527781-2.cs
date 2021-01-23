    var document = new Document();
    string path = Server.MapPath("AttachementToMail");
    var fileName =  DateTime.Now.ToString("yyyyMMdd")+".pdf";
    var fullPath = path + "\\" + fileName;
    
    //Write it to disk
    PdfWriter.GetInstance(document, new FileStream(fullPath, FileMode.Create));
    
    //Send it to output
    Response.ContentType = "Application/pdf";
    Response.AppendHeader("Content-Disposition", "attachment; filename="+ fileName );
    
    Response.TransmitFile(fullPath);
    Response.Flush();
    Response.End();
