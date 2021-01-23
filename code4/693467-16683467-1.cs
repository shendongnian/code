    int rowCount = 0;  
    while(rowCount < 40)
    {
        TableRow tr = new TableRow();
        int cellCount = 0;
        while(cellCount < 3)
        {
            TableCell tc = new TableCell();
            tc.Text = "cellText";
            tr.Cells.Add(tc);
            cellCount++;
        }
        Table1.Rows.Add(tr);
        rowCount++;
    }
