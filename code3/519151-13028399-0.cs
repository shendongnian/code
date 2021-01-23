    foreach (DataColumn c in DT.Columns)
    {
        iColumnCount++;
        if(iRowCount == 0)
            Worksheet.Cells[1, iColumnCount] = c.ColumnName;
        else
            Worksheet.Cells[iRowCount, iColumnCount] = c.ColumnName;
    
        Worksheet.Columns.AutoFit(); //Correct the width of the columns
        //THIS IS WHERE I WANT TO COLOR THE HEADERS
    }
    
            
        foreach (DataRow r in DT.Rows)
        {
            iRowCount++;
            iColumnCount = 0;
            foreach (DataColumn c in DT.Columns)
            {
                iColumnCount++;
                if(iRowCount == 1)
                    Worksheet.Cells[iRowCount + 1, iColumnCount] = r[c.ColumnName].ToString();
                else
                    Worksheet.Cells[iRowCount, iColumnCount] = r[c.ColumnName].ToString();
        
                Worksheet.Columns.AutoFit(); //Correct the width of the columns
            }
        }
