    private string customiseTemplate(string filename)
        {
            try
            {
                //Create Instance of Excel Appllication
                Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
    
                //Create a WorkBook Object.
                Workbooks wbks = app.Workbooks;
    
                //Populate Workbook from Excel File.
                _Workbook _wbk = wbks.Add(filename);
    
                //Create Sheet Object.
                Sheets shs = _wbk.Sheets;
    
                //Determine which sheet to work with. In this instance there should only ever be one. 
                _Worksheet _wsh = (_Worksheet)shs.get_Item(1);
    
                
    
                //Delete Unwanted Rows 1 to 3.
    
                Microsoft.Office.Interop.Excel.Range
                range1 = (Range)_wsh.get_Range("A1:A3", Missing.Value);
    
                range1.EntireRow.Delete(Missing.Value);
    
                // Release Range
                System.Runtime.InteropServices.Marshal.ReleaseComObject(range1);
    
                //Save WorkBook.
              
                app.AlertBeforeOverwriting = false;
    
                string newFile = filename.Insert(3, "Ammended_");
    
                _wbk.SaveAs(newFile, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, System.Reflection.Missing.Value, System.Reflection.Missing.Value, Missing.Value,
                Missing.Value, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
    
                // CLose Excel App.
                app.Quit();
    
                // Release unnecessary excel processes
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
                app = null;
    
                return newFile;
    
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
    
            return null;
        }
