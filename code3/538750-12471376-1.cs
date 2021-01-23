    protected void btnRead_Click(object sender, EventArgs e)
    {
        if (fileupload1.PostedFile != null && fileupload1.PostedFile.ContentLength > 0)
        {
            using (var reader = new StreamReader(fileupload1.PostedFile.InputStream))
            {
                textBoxContents.Text = reader.ReadToEnd();
            }
        }
    }
