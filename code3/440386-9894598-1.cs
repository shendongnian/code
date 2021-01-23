    this.Context.Response.Clear();
    this.Context.Response.ClearContent();
    this.Context.Response.ClearHeaders();
    this.Context.Response.BufferOutput = true;
    this.Context.Response.ContentType = "application/msword";
    this.Context.Response.AppendHeader("Content-Length", "12");
    this.Context.Response.AddHeader("Content-Disposition", "attachment; filename=" + "Test Document.doc");
    this.Context.Response.BinaryWrite(new byte[] { });
    this.Context.ApplicationInstance.CompleteRequest();
