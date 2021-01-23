    protected void lblHelp_Click(object sender, EventArgs e)
    {
        string filepath = Server.MapPath("~/VersionControlHelp.chm");    
        Process.Start(filepath);
    }
