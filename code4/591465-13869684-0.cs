    protected void btnDownload_Click(object sender, EventArgs e)
    {
        Response.AddHeader("Content-Disposition", "attachment;filename=myfilename.csv");
        Response.ContentType = "text/csv";
        Response.Write("1;computer;1000");
        Response.End();
    }
