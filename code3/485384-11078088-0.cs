    protected void btnExportExcel_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        GridView1.DataBind(); 
    
    
        GridView1.HeaderRow.Cells[0].Visible = false; 
    
        for (int i = 0; i < GridView1.Rows.Count;i++ )
        {
           GridViewRow row = GridView1.Rows[i];
           row.Cells[0].Visible = false;
           row.Cells[0].FindControl("chkCol0").Visible = false; 
         }
        GridView1.RenderControl(hw);
        Response.Write(style);
        Response.Output.Write(sw.ToString());
        Response.End();
    }
