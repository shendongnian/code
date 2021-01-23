    //In Default2.aspx
    protected void LinkButton1_Click(object sender, EventArgs e)
        {
           Response.Write(string.Format("<script>window.open('{0}','_blank');</script>", "Default3.aspx"));
        }
        
    //------------
    //In Default3.aspx
    
    protected void Page_Load(object sender, EventArgs e)
        {
            string path = Server.MapPath("~\\E:\\karthikeyan\\venky\\pdf\\aaaa.PDF");
            WebClient client = new WebClient();
            Byte[] buffer = client.DownloadData(path);
            if (buffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", buffer.Length.ToString());
                Response.BinaryWrite(buffer);
            }
        }
