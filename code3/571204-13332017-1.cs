    public void GridViewEfile_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Download")
        {
            //you can get your command argument values as follows
            string FileId=e.CommandArgument.ToString();
        }
     }
