    protected void btnSubmit_Click(object sender, EventArgs e) 
    {
       foreach (UploadedFile upload in Fu.UploadedFiles)
                    {
                        Fu.TargetFolder = "/Attachment/ClientProfile";
    
                        path = Server.MapPath(Fu.TargetFolder) + "\\" + upload.GetName();
                        upload.SaveAs(path);
    
                    }
    //Here give ImageName=path to save in database.
    }
