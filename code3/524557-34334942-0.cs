    Response.Clear();
    Response.ContentType = "application/pdf";
    Response.AppendHeader("Content-Disposition", "attachment; filename=FileName.pdf");
    Response.TransmitFile(Server.MapPath("~/folder/Sample.pdf"));
    Response.End(); 
