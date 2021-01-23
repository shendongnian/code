    protected void Page_Load(object sender, EventArgs e)
    {
         Response.Clear();
         Response.ClearContent();
         Response.ClearHeaders();
         Response.ContentType = "application/xml";
         Response.AddHeader("Content-Disposition", "attachment; filename=" +  Session["filePath"].ToString());
         Response.TransmitFile(Session["filePath"].ToString());
         Response.End();
    }
