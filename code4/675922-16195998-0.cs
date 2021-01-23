    Response.ClearContent();
    Response.ContentType = "application/pdf";
    Response.AddHeader("Content-Length", docSize.ToString());
    Response.BinaryWrite(docStream);
    Response.End();
