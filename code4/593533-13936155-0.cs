    context.Response.ContentType = "application/zip";
    context.Response.AddHeader("Content-Length", ms.Size);
    context.Response.AddHeader("Content-disposition", "attachment; filename=MyZipFile.zip");
    ms.Seek(0, SeekOrigin.Begin);
    ms.WriteTo(context.Response.OutputStream);
