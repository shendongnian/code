    private void ExportX()
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; Filename = ExcelReport.xls"));
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.ContentType = "application/ms-excel";
            StringWriter stringWrite = new StringWriter();
            HtmlTextWriter htmlWriter = new HtmlTextWriter(stringWrite);
            Table table = new Table();
            //  include the gridline settings
            table.GridLines = GridView1.GridLines;
            if (GridView1.HeaderRow != null)
            {
                PrepareControlForExport(GridView1.HeaderRow);
                table.Rows.Add(GridView1.HeaderRow);
            }
            foreach (GridViewRow row in GridView1.Rows)
            {
                PrepareControlForExport(row);
                table.Rows.Add(row);
            }
            if (GridView1.FooterRow != null)
            {
                PrepareControlForExport(GridView1.HeaderRow);
                table.Rows.Add(GridView1.FooterRow);
            }
            table.RenderControl(htmlWriter);
            Response.Write(stringWrite.ToString());
            Response.End();
        }
 
    public override void VerifyRenderingInServerForm(Control control)
        {
        }
