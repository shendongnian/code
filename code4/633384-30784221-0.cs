    public static class WorkbookExtensions
    {
        public static Excel.Worksheet GetWorksheetByName(this Excel.Workbook workbook, string name)
        {
            return workbook.Worksheets.OfType<Excel.Worksheet>().FirstOrDefault(ws => ws.Name == name);
        }
    }
