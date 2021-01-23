    transactionsList.ForEach(transaction => {
         TableRow row = new TableRow();
         valueList = new object[] { 
                                      transaction.Line, 
                                      transaction.EmpID, 
                                      transaction.SSN 
                                  };
         row.Cells.AddRange(valueList.Select(value => CreateCell(value))
                                .ToArray());
                      
    });
    private TableCell CreateCell(object cellText)
    {
        TableCell cell = new TableCell();
        cell.Text = Convert.ToString(cellText);
        return cell;
    }
