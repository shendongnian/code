    if (this.MyFileUpload.HasFile) {
        string SaveAs = this.SaveTo.Text.Trim().Replace('\\','/');
        string SaveFile = SaveAs;
        // Pull SavePath from web.config (should check that key exists first)
        string SavePath = System.Web.Configuration.WebConfigurationManager.AppSettings["SaveDirectory"];
        string SystemPath = string.Empty;
         // Handle case where SaveAs contains directory
        if (SaveAs.LastIndexOf("/") > -1) {
            SavePath = SavePath.TrimEnd('/') + "/" + SaveAs.Substring(0,SaveAs.LastIndexOf("/") + 1);
            SaveFile = SaveFile.Substring(SaveFile.LastIndexOf("/") + 1);
        }
         
        if (!SavePath.EndsWith("/"))  
            SavePath += "/"; 
        // Find the system path 
        SystemPath = System.Web.HttpContext.Current.Server.MapPath(SavePath);
        // Ensure the system path exists
        if (!System.IO.Directory.Exists(SystemPath))
            System.IO.Directory.CreateDirectory(SystemPath);
        // Ensure a filename was entered, if not use original file name
        if (string.IsNullOrEmpty(SaveFile))
            SaveFile = MyFileUpload.FileName;
        try
        {
            this.MyFileUpload.SaveAs(SystemPath + SaveFile);
        }
        catch (Exception ex)
        {
            txtMessage.Text = getFileName + " save failed.  " + ex.Message;
        }
        txtMessage.Text = "File " + getFileName + " saved successfully!";
    }
