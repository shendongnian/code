    public string GetPageName() 
    { 
        string path = System.Web.HttpContext.Current.Request.Url.AbsolutePath; 
        System.IO.FileInfo info = new System.IO.FileInfo(path); 
        return info.Name; 
    }
