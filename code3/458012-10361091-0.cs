      var worksheet = Globals.ThisAddin.Application.ActiveSheet
            worksheet.Name = "Export to Excel"; 
            Excel.Range mycell = (Excel.Range)worksheet.get_Range("A1:B1","A1:B1");  
            int CountColumn = ds.Tables[0].Columns.Count; 
            int CountRow = ds.Tables[0].Rows.Count; 
            int col = 0; 
            int row = 1; 
            string data = null; 
            int i = 0; 
            int j = 0; 
            for (col = 0; col < CountColumn; col++) 
            { 
                worksheet.Cells[row, col + 1] = ds.Tables[0].Columns[col].ColumnName.ToString(); 
            } 
 
