    const int FirstControl = 0;
    const int GriDefinedFieldsCount = 2;
    
    protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
    {
         if (e.Row.RowType == DataControlRowType.Header)
         {
             int col = 0;
             foreach (DataColumn dc in SiteManager.Reports.ReportData.Columns)
             {
                 if (dc.ColumnName == "Notes")
                 {
                     LinkButton lnk = (e.Row.Cells[col + GriDefinedFieldsCount].Controls[FirstControl] as LinkButton);
                     lnk.Width = Unit.Pixel(300);
                 }
                 col += 1;
             }
         }
