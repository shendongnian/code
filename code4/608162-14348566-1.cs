    private void GetData(string fileName, string tabName)
    {
        Application ExcelObj = new Application();
        Workbook theWorkbook = ExcelObj.Workbooks.Open(fileName,
            Type.Missing, Type.Missing, Type.Missing, Type.Missing,
            Type.Missing, Type.Missing, Type.Missing, Type.Missing,
            Type.Missing, Type.Missing, Type.Missing, Type.Missing,
            Type.Missing, Type.Missing);
        Sheets sheets = theWorkbook.Worksheets;
        Worksheet worksheet = (Worksheet)sheets[tabName];
        Range range = worksheet.get_Range("A1:A1", Type.Missing);
        string data = range.Text as string;
        // Your code...
        theWorkbook.Close(false, fileName, null);
    }
