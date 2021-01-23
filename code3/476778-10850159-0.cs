    protected void UploadButton_Click(object sender, EventArgs e)
    {
        if(FileUpload1.HasFile)
        {
            if(FileUpload1.PostedFile.ContentLength > 4096)
            {
                ErrorLabel.Text = "The file you are trying to upload exceeds the allowed limit.";
            }
            else
            {
                string SavePath = "TheLocationTheFilesSaves";
                FileUpload1.SaveAs(SavePath + FileUpload1.FileName);
                // Do stuff
            }
        }
    }
