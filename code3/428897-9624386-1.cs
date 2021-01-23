    public void Test()
    {
        Workbook book = Globals.ThisAddIn.Application.ActiveWorkbook;
        string wbkName = book.Name; //get and store the workbook name somewhere
        Worksheet sheet = (Worksheet)book.Worksheets[1]; // Get first worksheet
        book.Close(); // Close the workbook
        bool isNull = sheet == null; // false, worksheet is not null
        string name;
        if (WorkbookExists(wbkName))
        {
            name = sheet.Name; // will NOT throw a COM Exception
        }
    }
    private bool WorkbookExists(string name)
    {
        foreach (Microsoft.Office.Interop.Excel.Workbook wbk in Globals.ThisAddIn.Application.Workbooks)
        {
            if (wbk.Name == name)
            {
                return true;
            }
        }
        return false;
    }
