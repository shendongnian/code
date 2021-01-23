    Response.Clear();
    Response.ContentType = "application/pdf";
    Response.AppendHeader("Content-Disposition", "attachment; filename=foo.pdf");
    Response.TransmitFile(filePath);
    Response.End(); 
