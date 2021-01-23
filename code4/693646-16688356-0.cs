       protected void imgDownload_click(object sender, ImageClickEventArgs e)
    {
        ImageButton imgbtn = (ImageButton)sender;
        GridViewRow row = (GridViewRow)imgbtn.NamingContainer;
         string strHFFileDetails =((HiddenField )row.FindControl("HFFileID")) .Value.ToString();
        string[] strFileDetails = strHFFileDetails.Split('?');
        string FilePath = strFileDetails[1].ToString();
        string filename = gvFiles.Rows[row.RowIndex].Cells[0].Text.ToString();
        string path = @FilePath;
        System.IO.FileInfo file = new System.IO.FileInfo(path);
        if (file.Exists)
        {
            Response.Clear();
            Response.AppendHeader("Content-Disposition:", "attachment; filename=" + file.Name);
            Response.AppendHeader("Content-Length", file.Length.ToString());
            Response.ContentType = "application/octet-stream";
            Response.TransmitFile(file.FullName);
            Response.End();
        }
    }
