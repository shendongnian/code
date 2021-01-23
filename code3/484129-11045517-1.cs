    private Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
    
    private static string ReadSpreadsheet()
            {
    
                Workbook wb = null;
                wb = excel.Workbooks.Open("C:\APathToExcelSpreadsheet.xls", false, true);
    
                //Get the values in the sheet
                Range rng = wb.ActiveSheet.UsedRange;
                object[,] values;
                if (rng.Value2.GetType().IsArray)
                {
                    values = (object[,])rng.Value2;
                }
                else
                {
                    values = new object[2, 2];
                    values[1, 1] = rng.Value2;
                }
    
     
                for (int row = 1; row <= values.GetUpperBound(0); row++)
                {
                    for (int col = 1; col <= values.GetUpperBound(1); col++)
                    {
                        if (values[row, col] != null)
                        {
    ....
