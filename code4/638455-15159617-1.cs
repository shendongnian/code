    private void UpdateFormat(string path)
    {
        var application = new Microsoft.Office.Interop.Excel.Application();
        var doc = application.Workbooks.Open(path);
        for (int i = 1; i <= doc.Worksheets.Count; i++)
        {
            Worksheet sheet = doc.Worksheets[i];
            for (int j = 1; j <= sheet.Columns.Count; j++)
            {
                Range column = sheet.Columns[j];
                column.NumberFormat = "@";
            }
        }
        doc.Save();
        doc.Close();
        application.Quit();
    }
