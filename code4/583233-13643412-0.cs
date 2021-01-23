    protected void ProcessUpload(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
    {
    
        ....
        string path = Path.Combine(dir, name);
        Session["path"] = path;
    }
