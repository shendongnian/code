    protected void Page_Load(object sender, EventArgs e)
    {
        if(IsPostBack)
        {
            Boolean fileOK = false;
            String path = Server.MapPath("~/UploadedImages/");
            if (FileUpload1.HasFile) 
            {
                String fileExtension = 
                    System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
                String[] allowedExtensions = 
                    {".gif", ".png", ".jpeg", ".jpg"};
              for (int i = 0; i < allowedExtensions.Length; i++)
              {
                   if (fileExtension == allowedExtensions[i])
                   {
                        fileOK = true;
                   }
              }
            }
    
            if (fileOK)
            {
                try
                {
                    FileUpload1.PostedFile.SaveAs(path 
                        + FileUpload1.FileName);
                    Label1.Text = "File uploaded!";
                }
                catch (Exception ex)
                {
                    Label1.Text = "File could not be uploaded.";
                }
            }
            else
            {
                Label1.Text = "Cannot accept files of this type.";
            }
        }
    }
