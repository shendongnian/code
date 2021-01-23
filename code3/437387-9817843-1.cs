    private void RowCommand(object sender, GridViewCommandEventArgs e)
    {
            string fileName = e.CommandArgument;
            FileInfo file = new FileInfo(fileName);
            if (fileName != string.Empty && file.Exists)
            {
                Response.Clear();
                Response.AddHeader("Content-disposition", "attachment; filename=" + fileName.Substring(fileName.LastIndexOf("\\") + 1));
                Response.AddHeader("content-Length", file.Length.ToString());
                Response.ContentType = "application/octet-stream";
                Response.WriteFile(file.FullName);
                Response.Flush();
                Response.Close();
            } 
   
        }
