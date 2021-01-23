      Microsoft.Office.Interop.Excel.Application ExcelObj = null;
        
        ExcelObj = new Microsoft.Office.Interop.Excel.Application();
        if (ExcelObj == null)
        
        {
        
         MessageBox.Show("ERROR: EXCEL couldn't be started!");
        
         System.Windows.Forms.Application.Exit();
        
        }
        
        
        Microsoft.Office.Interop.Excel.Workbook theWorkbook = ExcelObj.Workbooks.Open(openFileDialog.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
        
        Type.Missing, Type.Missing, Type.Missing, Type.Missing,
        
        Type.Missing, Type.Missing, Type.Missing, Type.Missing,
        
        Type.Missing, Type.Missing);
        
        
        Microsoft.Office.Interop.Excel.Sheets sheets = theWorkbook.Worksheets;
        
        Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)sheets.get_Item(1);
        
        
        for(int x = 1; x <= 29; x++)
        
        {
        
        Microsoft.Office.Interop.Excel.Range range = worksheet.get_Range("A"+x.ToString(), "I" + x.ToString());
        
        System.Array myvalues = (System.Array)range.Cells.get_Value(range.);
        
        string[] strArray = ConvertToStringArray(myvalues);
        
        }
