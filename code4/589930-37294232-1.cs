    public string UploadFiles()
    {
        //this function handles the upload of gallery images and magazine file 
        var Request = HttpContext.Current.Request;
        System.Web.HttpFileCollection Files = Request.Files;
        try
        {
            for (int i = 0; i < Files.Count; i++)
            {
                System.Web.HttpPostedFile File = Files[i];
                File.SaveAs(HttpContext.Current.Server.MapPath("~/Uploads/" + File.FileName));
            }
            return "Files Saved Successfully!";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
