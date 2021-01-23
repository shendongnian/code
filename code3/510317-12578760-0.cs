    private void BtnWriteSpreedSheetClick(object sender, EventArgs e)
    {
        var xlApp = new Excel.Application();
        Excel.Workbook xlWorkBook = xlApp.Workbooks.Add();
        Excel.Worksheet xlWorkSheet = xlWorkBook.Sheets[1];
    
        xlWorkSheet.Cells[1, 1] = "http://csharp.net-informations.com";
        xlWorkSheet.Cells[2, 1] = "Adding picture in Excel File";
    
        xlWorkSheet.Shapes.AddPicture(@"C:\pic.JPG", MsoTriState.msoFalse, MsoTriState.msoCTrue, 50, 50, 300, 45);
    
        xlWorkBook.SaveAs("csharp.net-informations.xls", Excel.XlFileFormat.xlWorkbookNormal);
        xlWorkBook.Close(true);
        xlApp.Quit();
    
        releaseObject(xlApp);
        releaseObject(xlWorkBook);
        releaseObject(xlWorkSheet);
    
        MessageBox.Show("File created !");
    }
    
    private void releaseObject(object obj)
    {
        try
        {
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Unable to release the Object " + ex);
        }
        finally
        {
            GC.Collect();
        }
    }
