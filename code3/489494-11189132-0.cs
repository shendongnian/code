    var workbookPath = "";
    var worksheetName = "";
    
    var applicationClass = new Application();
    var workbook = applicationClass.Workbooks.Open(workbookPath, Type.Missing, Type.Missing,     Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing , Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
    
    var worksheet = workbook.GetWorksheet(worksheetName);
    var usedRange = worksheet.UsedRange;
    var columnRangeIndexColumn= 1;
               
    
                for (int i = beginIndexRow; i <= usedRange.Rows.Count; i++)
                {
                    var columnRange = usedRange.Cells[i, columnRangeIndexColumn];
                    var value= columnRange.Value2;
                 }
    
    
    
    
    use this extension
    
    public static Worksheet GetWorksheet(this Workbook value, string name)
            {
                foreach (Worksheet worksheet in value.Worksheets)
                {
                    if (worksheet.Name == name)
                    {
                        return worksheet;
                    }
                }
                return value.ActiveSheet;
            }
