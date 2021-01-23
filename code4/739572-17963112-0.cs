    public static void DownloadFile(string filename, string path)
    {
        Response.ContentType = "application/unknown";
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename);
        Response.TransmitFile(path);
        Response.End();
    }
