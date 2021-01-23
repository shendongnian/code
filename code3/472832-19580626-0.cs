        filename = Server.MapPath("~/Files/WM-0b23-productsBook.xlsx");
        Microsoft.Office.Interop.Excel.Application xlApp;
        Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
        Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
        var missing = System.Reflection.Missing.Value;
        xlApp = new Microsoft.Office.Interop.Excel.Application();
        xlWorkBook = xlApp.Workbooks.Open(filename, false, true, missing, missing, missing, true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, '\t', false, false, 0, false, true, 0);
        xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
        Microsoft.Office.Interop.Excel.Range xlRange = xlWorkSheet.UsedRange;
        Array myValues = (Array)xlRange.Cells.Value2;
        int vertical = myValues.GetLength(0);
        int horizontal = myValues.GetLength(1);
        System.Data.DataTable dt = new System.Data.DataTable();
        // must start with index = 1
        // get header information
        for (int i = 1; i <= horizontal; i++)
        {
            dt.Columns.Add(new DataColumn(myValues.GetValue(1, i).ToString()));
        }
        // Get the row information
        for (int a = 2; a <= vertical; a++)
        {
            object[] poop = new object[horizontal];
            for (int b = 1; b <= horizontal; b++)
            {
                poop[b - 1] = myValues.GetValue(a, b);
            }
            DataRow row = dt.NewRow();
            row.ItemArray = poop;
            dt.Rows.Add(row);
        }
        // assign table to default data grid view
        GridView1.DataSource = dt;
        GridView1.DataBind();
        xlWorkBook.Close(true, missing, missing);
        xlApp.Quit();
        releaseObject(xlWorkSheet);
        releaseObject(xlWorkBook);
        releaseObject(xlApp);
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
