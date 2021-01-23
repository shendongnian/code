    if (ASPxUploadControl1.HasFile)
    {
        try
        {
            string extension = Path.GetExtension(ASPxUploadControl1.FileName);
            string id = Guid.NewGuid().ToString();
            string fileLocation = string.Format("{0}/{1}{2}", 
                                                Server.MapPath("upload/"), 
                                                id, extension);
            ASPxUploadControl1.SaveAs( fileLocation );
            StatusLabel.Text = "Upload status: File uploaded!";
        }
        catch (Exception ex)
        {
            StatusLabel.Text = "Upload status: The file could not be uploaded. " 
                                + "The following error occured: " + ex.Message;
        }
    }
