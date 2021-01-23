    void Backup()
    {
        string connection = "server=localhost;user=root;pwd=qwerty;database=test;";
        string fileOnDisk = HttpContext.Current.Server.MapPath("~/MyDumpFile.sql");
        // Example Result: C:\inetpub\wwwroot\MyDumpFile.sql
        string fileOnWeb = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) 
                           + "/MyDumpFile.sql";
        // Example Result: http://www.mywebsite.com/MyDumpFile.sql
    
        // Backup MySQL Database
        MySqlBackup mb = new MySqlBackup(connection);
        mb.ExportInfo.FileName = fileOnDisk;
        mb.Export();
    
        // Download the file
        Response.ContentType = "text/plain";
        Response.AppendHeader("Content-Disposition", "attachment; filename=MyDumpFile.sql");
        Response.TransmitFile(fileOnDisk);
        Response.End();
    } 
