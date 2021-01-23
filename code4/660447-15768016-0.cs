    protected void btnpdf_Click(object sender, EventArgs e)
    {
    string path = Server.MapPath("SiteAnalytics.pdf");
    WebClient client = new WebClient();
    Byte[] buffer = client.DownloadData(path);
    
    if (buffer != null)
    {
    Response.ContentType = "application/pdf";
    Response.AddHeader("content-length", buffer.Length.ToString());
    Response.BinaryWrite(buffer);
    }
