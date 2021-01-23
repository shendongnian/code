     protected void btnSave_Click(object sender, EventArgs e)
     {
        Response.Clear();
        Response.AddHeader("content-isposition",attachment;filename=testExport.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.xls";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        divExport.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
     }
