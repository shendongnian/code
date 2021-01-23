    FileInfo fi = new FileInfo(@Request.PhysicalApplicationPath + File_Name);//
    long sz = fi.Length;
    Response.ClearContent();
    Response.ContentType = MimeType(Path.GetExtension(File_Name));
    Response.AddHeader("Content-Disposition", string.Format("attachment; filename = {0}", System.IO.Path.GetFileName(File_Name)));
    Response.AddHeader("Content-Length", sz.ToString("F0"));
    Response.TransmitFile(File_Name);
    Response.End();
