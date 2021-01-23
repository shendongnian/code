    private void createFILE(byte[] file, string Name)
    {
        int fileSize = file.Length;
    
        Response.AppendHeader("content-length", fileSize.ToString());
        Response.ContentType = "octet-stream";
        if (!Name.Contains("."))
            Name = Name + ".(your_extension)";
        Response.AddHeader("Content-Disposition", "attachment; filename=" + Name);
        Response.BinaryWrite(file);
        Response.Flush();
        Response.End();
    }
