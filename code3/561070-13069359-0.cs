    public List<string> Read()
    {
        List<string> list = new List<string>();
        Excel.Application xlApp = new Excel.Application();
        Excel.Workbooks xlWorkBooks = xlApp.Workbooks;
        Excel.Workbook xlWorkBook = xlWorkBooks.Open(sourceFile);
        Excel.Worksheet xlWorkSheet = xlWorkBook.Worksheets[ 1 ];
        System.Array myValues;
        Excel.Range range = xlWorkSheet.UsedRange;
        range = range.Cells;
        myValues = ( System.Array )range.Value;
        //The following is to ensure the EXCEL.EXE instance is released...
        //If you edit this code, know that using 2 dots (ex: range.Cells.Value) can create weird stuff!
        xlWorkBook.Close(false);
        xlWorkBooks.Close();
        xlApp.Quit();
        releaseObject(xlWorkSheet);
        releaseObject(xlWorkBook);
        releaseObject(xlWorkBooks);
        releaseObject(xlApp);
        xlWorkSheet = null;
        xlWorkBooks = null;
        xlWorkBook = null;
        xlApp = null;
        return list;
    }
    private static void releaseObject( object obj )
    {
	try
	{
		System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
		obj = null;
	}
	catch (Exception ex)
	{
		obj = null;
		Console.WriteLine("Unable to release the Object " + ex.ToString());
	}
    }
