    var tableControl = transactionsList.Aggregate(new Table(), (acc, transaction) => 
    {  
        TableRow row = new TableRow();
    
        TableCell cellLineNumber = new TableCell();
        cellLineNumber.Text = Convert.ToString(transaction.Line);
        row.Cells.Add(cellLineNumber);
    
        TableCell cellEmpID = new TableCell();
        cellEmpID.Text = Convert.ToString(transaction.EmpID);
        row.Cells.Add(cellEmpID);
    
        TableCell cellSSN = new TableCell();
        cellSSN.Text = transaction.SSN;
        row.Cells.Add(cellSSN);
    
        acc.Rows.Add(row);
        
        return acc;
    });
