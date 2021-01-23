    private void createDOC(byte[] file, string Name)
    {
        int fileSize = file.Length;
    
        Response.AppendHeader("content-length", fileSize.ToString());
        Response.ContentType = "application/msword";
        if (!Name.Contains("."))
            Name = Name + ".doc";
        Response.AddHeader("Content-Disposition", "attachment; filename=" + Name);
        Response.BinaryWrite(file);
        Response.Flush();
        Response.End();
    }
