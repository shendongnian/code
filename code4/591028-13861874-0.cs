     if (e.Row.RowType == DataControlRowType.Pager)
            {
    
                Table pagerTable = (e.Row.Cells[0].Controls[0] as Table);
                TableRow row = new TableRow();
                row = pagerTable.Rows[0];
                TableCell cell1 = new TableCell();
                cell1.Controls.Add(ImageButton1);
            
                row.Cells.AddAt(1,cell1);
    }
