    protected void gvStatusReport_RowCreated(object sender, GridViewRowEventArgs e)
       {
          if (e.Row.RowType == DataControlRowType.Header)
          {
             GridView HeaderGrid = (GridView)sender;
             GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
             TableCell HeaderCell = new TableCell();
             HeaderCell.ColumnSpan = 6;
             HeaderGridRow.Cells.Add(HeaderCell);
    
             HeaderCell = new TableCell();
             HeaderCell.Text = "Time Spent";
             HeaderCell.ColumnSpan = 7;
             HeaderGridRow.Cells.Add(HeaderCell);
    
             HeaderCell = new TableCell();
             HeaderCell.Text = "Total";
             HeaderCell.ColumnSpan = 2;
             HeaderGridRow.Cells.Add(HeaderCell);
    
             HeaderCell = new TableCell();
             HeaderCell.ColumnSpan = 6;
             HeaderGridRow.Cells.Add(HeaderCell);
    
             gvStatusReport.Controls[0].Controls.AddAt(0, HeaderGridRow);
          }
       }
