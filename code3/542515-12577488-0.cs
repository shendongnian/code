    transactionsList.ForEach(transaction => {
    
        TableRow row = new TableRow();
    
        AddCellToRow(row, transaction.Line);
        AddCellToRow(row,  transaction.EmpID);
        AddCellToRow(row, transaction.SSN);
    
        tableControl.Rows.Add(row);
    
        });
    
    private TableCell AddCellToRow(TableRow row, object cellText)
    {
        TableCell cell = new TableCell();
        cell.Text = Convert.ToString(cellText);
        row.Cells.Add(cell);
    }
