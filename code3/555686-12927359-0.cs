    using Excel = Microsoft.Office.Interop.Excel;
    
    Excel.Application xlApp = new Excel.Application();
    Excel.Workbook xlWorkbook = xlApp.Workbooks.Open("path to book");
    Excel.Worksheet xlSheet = xlWorkbook.Sheets[1]; // get first sheet
    Excel.Range xlRange = xlSheet.UsedRange; // get the entire used range
    
    int numberOfRows = xlRange.Rows.Count;
    int numberOfCols = xlRange.Columns.Count;
    List<int> columnsToRead = new List<int>();
    
    List<string> columnValue = new List<string>();
    // loop over each column number and add results to the list
    
    int c = 3; // Column 'C'
    for(int r = 19; r <= numberOfRows; r++)
    {
        if(xlRange.Cells[r,c].Value2 != null) // ADDED IN EDIT
        {
            columnValue.Add(xlRange.Cells[r,c].Value2.ToString());
        }
    }
