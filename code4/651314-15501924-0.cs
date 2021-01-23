                            Microsoft.Office.Interop.Excel.Application xlApp;
                            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                            object misValue = System.Reflection.Missing.Value;
        
                            xlApp = new Microsoft.Office.Interop.Excel.Application(); 
                            xlWorkBook = xlApp.Workbooks.Add(misValue); 
                            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);    
                      
                            xlWorkSheet.Cells[1, 1] = "xxx";
                            xlWorkSheet.Cells[2, 1] = "yyy";
        
        
                            xlWorkSheet.get_Range("A1", "A7").Borders.Weight = 2;
                            xlWorkSheet.get_Range("A1", "A7").Font.Bold = true;
                            xlWorkSheet.get_Range("A1", "A7").Font.Size = 13;
        
                            xlWorkSheet.get_Range("A2", "A7").Borders.Weight = 2;
                            xlWorkSheet.get_Range("A2", "A7").Font.Bold = true;
                            xlWorkSheet.get_Range("A2", "A7").Font.Size = 13;
        
                            xlWorkSheet.get_Range("A1", "B9").ColumnWidth = 25;
    
        
                            
                            xlWorkBook.SaveAs(System.Windows.Forms.Application.StartupPath + "\\exceller\\6 Nolu sosyal ve kültürel faaliyetler\\" +
                                txtFaaliyetAdi.Text + ".xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue
                            , misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                            
        
                            xlWorkBook.Close(true, misValue, misValue); 
                            xlApp.Quit();
