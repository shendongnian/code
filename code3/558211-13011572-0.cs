    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            System.Web.HttpPostedFile file = Request.Files["fUpload"];
            if (file != null && file.ContentLength > 0)
            {
                file.SaveAs(@"C:\dir\"+System.IO.Path.GetFileName(file.FileName));
            }
        }
    }
