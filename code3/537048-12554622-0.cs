    protected string GetInitParams()
    {
        string xappath = HttpContext.Current.Server.MapPath(@"~/ClientBin/YourXapFile.xap");
        DateTime xapCreationDate = System.IO.File.GetLastWriteTime(xappath);
        return string.Format("lastUpdateDate={0:d}, xapCreationDate);
    }
