    if (ds != null && ds.Tables[0].Rows.Count > 0)
    {
        Table table = new Table();
        table.ID = "Table1";
    
        // j is the row index
        for (int j == 0; j < ds.Tables[0].Rows.Count; j++)
        {
            TableRow row = new TableRow();
            // i is the column index
            for (int i = 0; i < 5; i++)
            {
                 TableCell cell = new TableCell();
                 TextBox tb1 = new TextBox();
                 TextBox tb2 = new TextBox();
    
                 tb1.ID = "txtDateRow" + j + "Col" + i;
                 tb1.Text = ds.Tables[0].Rows[j]["Date"].ToString();
                 tb2.ID = "txtDetails" + j + "Col" + i;
                 tb2.Text = ds.Tables[0].Rows[j]["AmountSold"].ToString();
                 cell.Controls.Add(tb1);
                 cell.Controls.Add(tb2);
                 row.Cells.Add(cell);
            }
            table.Rows.Add(row);
        }
        Panel1.Controls.Add(table);
    }
