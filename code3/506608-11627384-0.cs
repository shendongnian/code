    private void ExportToExcel(string fileName, DataGridView dgv) //Exports the given dataGridView to Excel with the given fileName
            {
                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
    
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                int i = 0;
                int j = 0;
    
                DataTable dtExcelTable = GetDataTableForExcel(dgv);
    
                for (i = 0; i < dtExcelTable.Columns.Count; i++)
                {
                    xlWorkSheet.Cells[1, i + 1] = dtExcelTable.Columns[i].ColumnName;
                }
    
                for (i = 0; i < dtExcelTable.Rows.Count; i++)
                {
                    for (j = 0; j < dtExcelTable.Columns.Count; j++)
                    {
                        xlWorkSheet.Cells[i + 2, j + 1] = dtExcelTable.Rows[i][j];
                    }
                }
    
                try
                {
                    xlWorkBook.SaveAs(fileName + ".xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                    xlWorkBook.Close(true, misValue, misValue);
                    xlApp.Quit();
    
                    releaseObject(xlWorkSheet);
                    releaseObject(xlWorkBook);
                    releaseObject(xlApp);
    
                    MessageBox.Show("Excel dosyanız C:\\" + fileName + ".xls uzantısında yaratıldı.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir sorun oluştu, tekrar deneyiniz. Hata: " + ex.Message);
                }
    
            }
