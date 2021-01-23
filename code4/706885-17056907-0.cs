    Protected void ButtonA_Click(object sender, EventArgs e)
    {
         Response.Clear();
         Response.AddHeader("content-disposition", "attachment;filename=Filename.xls");
         Response.ContentType = "application/vnd.xlsx";
         System.IO.StringWriter stringWrite = new System.IO.StringWriter();
         System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
         GridView1.RenderControl(htmlWrite);
         Response.Write(stringWrite.ToString());
         Response.End();
    }
