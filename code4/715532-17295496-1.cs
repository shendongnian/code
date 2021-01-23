    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Upload")
        {
            FileUpload FileUp = (FileUpload)e.Item.FindControl("FileUpload1");
            string UploadedFileName = FileUp.FileName;
            string Path = Server.MapPath("Documents");
            FileUpload.SaveAs(Path + "\\" + UploadedFileName);
        }
    }
