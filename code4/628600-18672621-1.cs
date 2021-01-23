    protected void btnDownload_Click(object sender, EventArgs e)
    {
        string filename=MapPath("birds.jpg");
        Response.ContentType = "image/JPEG";
        Response.AddHeader("Content-Disposition", "attachment; filename=" + filename+ "");
        Response.TransmitFile(filename);
        Response.End();
    }
