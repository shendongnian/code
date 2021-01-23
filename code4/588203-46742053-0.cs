             Hi guys m posting this because this code is used to copy the formula behind a cell in Excel
 
        public void copy_Formula_behind_cell()
        {
            Excel.Application xlapp;
            Excel.Workbook xlworkbook;
            Excel.Worksheet xlworksheet;
            Excel.Range xlrng;
            object misValue = System.Reflection.Missing.Value;
            xlapp = new Excel.Application();
            xlworkbook =xlapp.Workbooks.Open("YOUR_FILE", 0, true, 5, "", 
            "",true,Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", 
            false, 
            false, 0, true, 1, 0);
            xlworksheet = (Excel.Worksheet)xlworkbook.Worksheets.get_Item(1);
            string sp = xlworksheet.Cells[3,2].Formula;//It will Select Formula 
                                                          using Fromula method//
          xlworksheet.Cells[8,2].Formula = 
            xlapp.ConvertFormula(sp,XlReferenceStyle.xlA1, 
            XlReferenceStyle.xlR1C1, XlReferenceType.xlAbsolute,
            xlworksheet.Cells[8][2]);
                  //This is used to Copy the exact formula to where you want//
           
            xlapp.Visible = true;
            xlworkbook.Close(true, misValue, misValue);
            xlapp.Quit();
            releaseObject(xlworksheet);
            releaseObject(xlworkbook);
            releaseObject(xlapp);
        }
        
    private void releaseObject(object obj)
    {
        try
        {
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
            obj = null;
        }
        catch (Exception ex)
        {
            obj = null;
            MessageBox.Show("Unable to release the Object " + ex.ToString());
        }
        finally
        {
            GC.Collect();
        }
    }
