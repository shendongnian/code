    ApplicationClass app = new ApplicationClass();
    app.Visible = false;
    app.ScreenUpdating = false;
    app.DisplayAlerts = false;
    Workbook book = app.Workbooks.Open(@"path\Book1.xls", 
        Missing.Value, Missing.Value, Missing.Value, 
        Missing.Value, Missing.Value, Missing.Value, Missing.Value, 
        Missing.Value, Missing.Value, Missing.Value, Missing.Value, 
        Missing.Value, Missing.Value, Missing.Value);
    Worksheet sheet = (Worksheet)book.Worksheets[1];
    Range range = sheet.get_Range(...);
    string execPath = Path.GetDirectoryName(
        Assembly.GetExecutingAssembly().CodeBase);
    object[,] values = (object[,])range.Value2;
    for (int i = 1; i <= values.GetLength(0); i++)
    {
        for (int j = 1; j <= values.GetLength(1); j++)
        {
            string s = values[i, j].ToString();
        }
    }
