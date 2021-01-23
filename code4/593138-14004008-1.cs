    void Restore()
    {
        string connection = "server=localhost;user=root;pwd=qwerty;database=test;";
        string fileOnDisk = HttpContext.Current.Server.MapPath("~/MyDumpFile.sql");
        string fileOnWeb = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) 
                           + "/MyDumpFile.sql";
        // Upload the file
        if (FileUpload1.HasFile)
        {
            FileUpload1.SaveAs(fileOnDisk);
    
            MySqlBackup mb = new MySqlBackup(connection);
            mb.ImportInfo.FileName = fileOnDisk;
            mb.Import();
            Response.Write("Import Successfully");
        }
    }
