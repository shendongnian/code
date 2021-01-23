    TableRow  tempRow= new TableRow();
    Table  xTblTemp= new Table();
    for (int i = 0; i < xTblComplete.Rows[0].Cells.Count - 1; i++)
    {
      TableCell cell = xTblComplete.Rows[0].Cells[i];
      tempRow.Cells[i].Text = cell.Text;      
    }
    xTblTemp.Rows.Add(tempRow);
