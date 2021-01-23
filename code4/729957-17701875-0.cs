    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
          if (e.Row.RowType == DataControlRowType.DataRow)
          {
               DataRowView drv = e.Row.DataItem as DataRowView;
               if (drv != null)
               {
                   // your code here...
               }
          }
    }
