    protected void download_file(string path)
    {
       var filename = "YourFile.pdf";
       Response.ContentType = "application/pdf";
       Response.AppendHeader("Content-Disposition", "attachment; filename='someName'" );
       Response.TransmitFile(path + "\" + filename );
       Response.End();
    }
