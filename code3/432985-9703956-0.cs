    using Excel = Microsoft.Office.Interop.Excel;
    Excel.Application xlApp = new Excel.Application();
    Excel.Workbook xlWorkbook = xlApp.Workbooks.Open("path to book");
    Excel.Worksheet xlSheet = xlWorkbook.Sheets[1]; // get first sheet
    Excel.Range xlRange = xlSheet.UsedRange; // get the entire used range
    int numberOfRows = xlRange.Rows.Count;
    int numberOfCols = xlRange.Columns.Count;
    List<int> columnsToRead = new List<int>();
    // find the columns that correspond with the string columnName which
    // would be passed into your method
    for(int i=1; i<=numberOfCols; i++)
    {
        if(xlRange.Cells[1,i].Value2.ToString().Equals(categoryName))
        {
            columnsToRead.Add(i);
        }
    }
    List<string> columnValue = new List<string>();
    // loop over each column number and add results to the list
    foreach(int c in columnsToRead)
    {
        // start at 2 because the first row is 1 and the header row
        for(int r = 2; r <= numberOfRows; r++)
        {
            columnValue.Add(xlRange.Cells[r,c].Value2.ToString());
        }
    }
