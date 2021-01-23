    protected void grdExamReportBatchWise_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItem != null)
        {
         for (int i = 0; i < grdExamReportBatchWise.Columns.Count - 1; i++)
              {
                  if (e.Row.Cells[i].Text == "Paper")
                            {
                             string ne = "abc";
                            } 
              }
         }
      }
