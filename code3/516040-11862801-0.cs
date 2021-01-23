            protected void btnExcel_Click(object sender, ImageClickEventArgs e)
        {
            //export to excel
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=FileName.xls");
            Response.Charset = "";
        
            // If you want the option to open the Excel file without saving then
            // comment out the line below
            // Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.xls";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
           //GV is the ID of gridview
            GV.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();
        }
