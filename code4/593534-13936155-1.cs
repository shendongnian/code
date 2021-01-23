    using (MemoryStream ms = new MemoryStream())
    {
        using (ZipFile zip = new ZipFile())
        {
           zip.AddFile("ReadMe.txt");
           zip.AddFile("7440-N49th.png");
           zip.AddFile("2008_Annual_Report.pdf");        
           zip.Save(ms); // this will save the files in memory steam
        }
        context.Response.ContentType = "application/zip";
        context.Response.AddHeader("Content-Length", ms.Size);
        context.Response.AddHeader("Content-disposition", "attachment; filename=MyZipFile.zip");
        ms.Seek(0, SeekOrigin.Begin);
        ms.WriteTo(context.Response.OutputStream);
    }
