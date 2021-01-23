    //Declare your variables
    Application excel = null;
    Workbook excelworkBook = null;
    Range excelCellrange = null;
    Worksheet worksheet = null;
    Font excelFont =null;
    //start your application
    excel = new Application();
    try
    {
       ...
       //your code goes here...
       excelCellrange = worksheet.Range[worksheet.Cells[1,7],worksheet.Cells[1,7]];
       excelFont = excelCellrange.Font;
       excelfont.Size = 20;
       ...
       ...
    }
    catch(Exception ex){
    }
    finally{
       //here put something to clean the interop objects as the link above.
       ...
       Marshal.ReleaseComObject(excelfont);
       ...
    }
  
