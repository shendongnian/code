    #region Excel Interop Object Private Methods
    private void ExportToExcel()
    {
        #region Initialize Variables
        DataTable dataGridView1 = new DataTable();
        //Load source
        dataGridView1 = YOUR_DATATABLE_HERE;
        //Declare Excel Interop variables
        Microsoft.Office.Interop.Excel.Application xlApp;
        Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
        Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
        object misValue = System.Reflection.Missing.Value;
        //Initialize variables
        xlApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
        xlWorkBook = xlApp.Workbooks.Add(misValue);
        xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
        #endregion
        #region Title
        //Add a title
        xlWorkSheet.Cells[1, 1] = "Your title here";
        //Span the title across columns A through H
        Microsoft.Office.Interop.Excel.Range titleRange = xlApp.get_Range(xlWorkSheet.Cells[1, "A"], xlWorkSheet.Cells[1, "F"]);
        titleRange.Merge(Type.Missing);
        //Center the title horizontally then vertically at the above defined range
        titleRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        titleRange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
        //Increase the font-size of the title
        titleRange.Font.Size = 16;
        //Make the title bold
        titleRange.Font.Bold = true;
        //Give the title background color
        titleRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
        //Set the title row height
        titleRange.RowHeight = 50;
        #endregion
        #region Column Headers
        //Populate headers, assume row[0] contains the title and row[1] contains all the headers
        int iCol = 0;
        foreach (DataColumn c in dataGridView1.Columns)
        {
            iCol++;
            xlWorkSheet.Cells[2, iCol] = dgResults.Columns[iCol - 1].HeaderText;
        }
        //Populate rest of the data. Start at row[2] since row[1] contains title and row[0] contains headers
        int iRow = 2; //We start at row 2
        foreach (DataRow r in dataGridView1.Rows)
        {
            iRow++;
            iCol = 0;
            foreach (DataColumn c in dataGridView1.Columns)
            {
                iCol++;
                xlWorkSheet.Cells[iRow, iCol] = r[c.ColumnName];
            }
        }
        //Select the header row (row 2 aka row[1])
        Microsoft.Office.Interop.Excel.Range headerRange = xlApp.get_Range(xlWorkSheet.Cells[2, "A"], xlWorkSheet.Cells[2, "F"]);
        //Set the header row fonts bold
        headerRange.Font.Bold = true;
        //Center the header row horizontally
        headerRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        //Put a border around the header row
        headerRange.BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous,
            Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium,
            Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic,
            Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic);
        //Give the header row background color
        headerRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.MediumPurple);
        #endregion
        #region Page Setup
        //Set page orientation to landscape
        xlWorkSheet.PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlLandscape;
        //Set margins
        xlWorkSheet.PageSetup.TopMargin = 0;
        xlWorkSheet.PageSetup.RightMargin = 0;
        xlWorkSheet.PageSetup.BottomMargin = 30;
        xlWorkSheet.PageSetup.LeftMargin = 0;
        //Set Header and Footer (see code list below)
        //&P - the current page number.
        //&N - the total number of pages.
        //&B - use a bold font*.
        //&I - use an italic font*.
        //&U - use an underline font*.
        //&& - the '&' character.
        //&D - the current date.
        //&T - the current time.
        //&F - workbook name.
        //&A - worksheet name.
        //&"FontName" - use the specified font name*.
        //&N - use the specified font size*.
        //EXAMPLE: xlWorkSheet.PageSetup.RightFooter = "&F"
        xlWorkSheet.PageSetup.RightHeader = "";
        xlWorkSheet.PageSetup.CenterHeader = "";
        xlWorkSheet.PageSetup.LeftHeader = "";
        xlWorkSheet.PageSetup.RightFooter = "";
        xlWorkSheet.PageSetup.CenterFooter = "Page &P of &N";
        xlWorkSheet.PageSetup.LeftFooter = "";
        //Set gridlines
        xlWorkBook.Windows[1].DisplayGridlines = true;
        xlWorkSheet.PageSetup.PrintGridlines = true;
        #endregion
        
        #region Worksheet Style
        /* 
        //Color every other column but skip top two
        Microsoft.Office.Interop.Excel.Range workSheetMinusHeader = xlApp.get_Range("A1", "F1");
        Microsoft.Office.Interop.Excel.FormatCondition format =
            (Microsoft.Office.Interop.Excel.FormatCondition)workSheetMinusHeader.EntireColumn.FormatConditions.Add(
                Microsoft.Office.Interop.Excel.XlFormatConditionType.xlExpression,
                Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlEqual,
                "=IF(ROW()<3,,MOD(ROW(),2)=0)");
        format.Interior.Color = Microsoft.Office.Interop.Excel.XlRgbColor.rgbWhiteSmoke;
        //Put a border around the entire work sheet
        workSheetMinusHeader.EntireColumn.BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous,
            Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium,
            Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic,
            Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic);
        */
        #endregion
        #region Specific Width, Height, Wrappings, and Format Types
        //Set the font size and text wrap of columns for the entire worksheet
        string[] strColumns = new string[] { "A", "B", "C", "D", "E", "F" };
        foreach (string s in strColumns)
        {
            ((Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Columns[s, Type.Missing]).Font.Size = 12;
            ((Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Columns[s, Type.Missing]).WrapText = true;
        }
        //Set Width of individual columns
        ((Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Columns["A", Type.Missing]).ColumnWidth = 7.00;
        ((Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Columns["B", Type.Missing]).ColumnWidth = 18.00;
        ((Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Columns["C", Type.Missing]).ColumnWidth = 18.00;
        ((Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Columns["D", Type.Missing]).ColumnWidth = 30.00;
        ((Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Columns["E", Type.Missing]).ColumnWidth = 40.00;
        ((Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Columns["F", Type.Missing]).ColumnWidth = 15.00;
        //Select everything except title row (first row) and set row height for the selected rows
        //xlWorkSheet.Range["a2", xlWorkSheet.Range["a2"].End[Microsoft.Office.Interop.Excel.XlDirection.xlDown].End[Microsoft.Office.Interop.Excel.XlDirection.xlToRight]].RowHeight = 45;
        //Format date columns
        //string[] dateColumns = new string[] { "N", "O", "P", "Q" };
        string[] dateColumns = new string[] { };
        foreach (string thisColumn in dateColumns)
        {
            Microsoft.Office.Interop.Excel.Range rg = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, thisColumn];
            rg.EntireColumn.NumberFormat = "MM/DD/YY";
        }
        //Format ID column and prevent long numbers from showing up as scientific notation
        //Microsoft.Office.Interop.Excel.Range idRange = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, "C"];
        //idRange.EntireColumn.NumberFormat = "#";
        //Format Social Security Numbers so that Excel does not drop the leading zeros
        //Microsoft.Office.Interop.Excel.Range idRange = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, "C"];
        //idRange.EntireColumn.NumberFormat = "000000000";
        #endregion
        #region Save & Quit
        //Save and quit, use SaveCopyAs since SaveAs does not always work
        string fileName = Server.MapPath("~/YourFileNameHere.xls");
        xlApp.DisplayAlerts = false; //Supress overwrite request
        xlWorkBook.SaveAs(fileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
        xlWorkBook.Close(true, misValue, misValue);
        xlApp.Quit();
        //Release objects
        releaseObject(xlWorkSheet);
        releaseObject(xlWorkBook);
        releaseObject(xlApp);
        //Give the user the option to save the copy of the file anywhere they desire
        String FilePath = Server.MapPath("~/YourFileNameHere.xls");
        System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
        response.ClearContent();
        response.Clear();
        response.ContentType = "text/plain";
        response.AddHeader("Content-Disposition", "attachment; filename=YourFileNameHere-" + DateTime.Now.ToShortDateString() + ".xls;");
        response.TransmitFile(FilePath);
        response.Flush();
        response.Close();
        //Delete the temporary file
        DeleteFile(fileName);
        #endregion
    }
    private void DeleteFile(string fileName)
    {
        if (File.Exists(fileName))
        {
            try
            {
                File.Delete(fileName);
            }
            catch (Exception ex)
            {
                //Could not delete the file, wait and try again
                try
                {
                    System.GC.Collect();
                    System.GC.WaitForPendingFinalizers();
                    File.Delete(fileName);
                }
                catch
                {
                    //Could not delete the file still
                }
            }
        }
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
            Response.Write("Exception Occured while releasing object " + ex.ToString());
        }
        finally
        {
            GC.Collect();
        }
    }
    #endregion
