    <!-- language: c# -->
    // Declare a DataTable variable
    public DataTable myTable;
    // Open the workbook.
    String filename = HttpContext.Server.MapPath("myspreadsheet.xlsx");
    SpreadsheetGear.IWorkbook workbook = SpreadsheetGear.Factory.GetWorkbook(filename);
    
    //Get the table as a dataset:
    DataSet dataSet = workbook.GetDataSet("MyTable", SpreadsheetGear.Data.GetDataFlags.FormattedText);
    myTable = dataSet.Tables[0];
    
    //Which can also be written as:
    myTable = workbook.GetDataSet("MyTable", SpreadsheetGear.Data.GetDataFlags.FormattedText).Tables[0];
