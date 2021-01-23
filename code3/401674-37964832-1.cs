         private double AutoSizeMergedCells( string text)        
        { 
            Excel.Worksheet ws = xlWorkBook.Sheets[1];
             `enter code here`ws.Cells[14, 10].ColumnWidth = 9.29+7.43+10.71+11.29;(size width range)
             ws.Cells[14, 10].Value = text;
                 ws.Cells[14, 10].Style.WrapText = true;
                        ws.Cells[14, 10].Rows.AutoFit();
                        var result = ws.Cells[14, 10].RowHeight;  
              ws.Cells[14, 10].Value = "";
                        return result;
    }
