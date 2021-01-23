    TableRow tRow
    TableCell tCell
    for(int i = startTemp; i < endTemp; i += iterator)
    {
    tRow = new TableRow();
    tRow.CssClass = (i % 2 == 0 ? "white" : "grey");
    tempTable.Rows.Add(tRow);
    tCell = new TableCell();
    tCell.Text = i.ToString();
    tRow.Cells.Add(tCell);
    tCell = new TableCell();
    tCell.Text = convert(i);
    
    tRow.Cells.add(tCell);
    tempTable.Rows.Add(tRow);
    }
    
 
