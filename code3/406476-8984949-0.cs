    public static void DeleteRow(string pathToFile, string sheetName, string cellRef)
    {
        Application app= new Application();
        Workbook  workbook = app.Workbooks.Open(pathToFile);
        for (int sheetNum = 1; sheetNum <  workbook.Sheets.Count + 1; sheetNum++)
        {
            Worksheet sheet = (Worksheet)workbook.Sheets[sheetNum];
            if (sheet.Name != sheetName)
            {
                continue;
            }
            Range secondRow = sheet.Range[cellRef];
            secondRow.EntireRow.Delete();
        }
        workbook.Save();
        workbook.Close();
        app.Quit();
    }
