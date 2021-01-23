    protected void upload_Click(object sender, EventArgs e)
    {
        string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
        FileUpload1.SaveAs(Server.MapPath("~/Images/"+Model.Text+"/" + filename));
        BindDataList();
    }
    protected void newfolder_Click(object sender, EventArgs e)
    {
        string NewDirectory = Server.MapPath("~/Images/"+Model.Text);
        //New Directory Name in string variable
        CreateDirectoryIfNotExists(NewDirectory);
        //Calling the function to create new directory
    }
