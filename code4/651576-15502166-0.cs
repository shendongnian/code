    try
    {
        wBook = xCel.Workbooks.Open(ExcelPath);                
        wSheet = (Excel.Worksheet)wBook.Worksheets.get_Item(1);                    
        wSheet.Copy(Type.Missing, Type.Missing);                    
        wSheet = (Excel.Worksheet)wBook.Sheets[1];
        wSheet.SaveAs(ExcelCopyPath);
     }
    catch(Exception ex) 
	{
		using(var sw = new StreamWriter(@"C:\temp\mylog.txt", true))
		{
			sw.WriteLine("First catch block");
			sw.WriteLine(ex.Message);
		}
	}
    finally
    {                
        if (wBook != null)
        {                    
            wBook.Close();
            wSheet = null;
            wBook = null;
            Thread.Sleep(500);
        }
        if (Excel.ProcessID > 0)
         {
            Process pxCel = Process.GetProcessById(Excel.ProcessID);
            pxCel.Kill();
         }
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
        GC.WaitForPendingFinalizers();                
        try { Marshal.FinalReleaseComObject(wSheet);}
    catch(Exception ex) 
	{
		using(var sw = new StreamWriter(@"C:\temp\mylog.txt", true))
		{
			sw.WriteLine("Second catch block");
			sw.WriteLine(ex.Message);
		}
	}                                     
        try { Marshal.FinalReleaseComObject(wBook);}
    catch(Exception ex) 
	{
		using(var sw = new StreamWriter(@"C:\temp\mylog.txt", true))
		{
			sw.WriteLine("Third catch block");
			sw.WriteLine(ex.Message);
		}
	}              
    }
