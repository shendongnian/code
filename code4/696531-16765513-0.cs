    protected void download_file(object sender, EventArgs e)
    {
        filename = "Server side exc 2PLATINA.JPG";
        string path = ((Button)sender).CommandArgument;;
        Response.ContentType = "application/pdf";
        Response.AppendHeader("Content-Disposition", "attachment; filename='someName'" );
        Response.TransmitFile(val);
        Response.End();
    }
