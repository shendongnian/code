    protected void grvTermsAndConditions_rowDataBound(Object sender, GridViewRowEventArgs e)
        {
                 if(e.Row.RowType == DataControlRowType.DataRow) // Use this if condition otherwise exception is occurred
                 {
                          if(e.RowIndex == 0)
                          {
                                 e.Row.CssClass = "gvRowRed";
                    e.Row.Cells[0].CssClass = "white";
                    e.Row.Cells[1].CssClass = "white";
                          }
                 }            
        }
