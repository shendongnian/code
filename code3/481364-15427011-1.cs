    Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
    
        ExcelApp.Application.Workbooks.Add(Type.Missing);
    
        // Change properties of the Workbook 
        ExcelApp.Columns.ColumnWidth = 20;
    
        // Storing header part in Excel
        for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
        {
            ExcelApp.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
        }
    
        // Storing Each row and column value to excel sheet
        for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
        {
            for (int j = 0; j < dataGridView1.Columns.Count; j++)
            {
                ExcelApp.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                
               
            }
        }
    
        ExcelApp.ActiveWorkbook.SaveCopyAs("F:\\Exportdata\\" + "DealEntry.xls");
        ExcelApp.ActiveWorkbook.Saved = true;
        MessageBox.Show("It's Saved on Path F:\\Exportdata\\DealEntry.Xls");
        ExcelApp.Quit();
        ExcelApp.Visible = true;
        string workbookPath = "F:\\Exportdata\\" + "DealEntry.xls";  // Add your own path here
        Microsoft.Office.Interop.Excel.Workbook excelWorkbook = ExcelApp.Workbooks.Open(workbookPath, 0,
            false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true,
            false, 0, true, false, false);
    
    }
    catch { }
