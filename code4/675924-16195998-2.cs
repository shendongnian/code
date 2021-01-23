    protected void lnkButton_Click(object sender, EventArgs e)
    {
        Response.ClearContent();
        Response.ContentType = "application/pdf";
        Response.AddHeader("Content-Disposition", "inline; filename=" + docName);
        Response.AddHeader("Content-Length", docSize.ToString());
        Response.BinaryWrite((byte[])docStream);
        Response.End();
    }
