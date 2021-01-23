    public static bool SheetExists(this Excel.Workbook wbk, string sheetName)
    {
        for (int i = 1; i <= wbk.Worksheets.Count; i++)
        {
            if (((Excel.Worksheet)wbk.Worksheets[i]).Name == sheetName)
            {
                return true;
            }
        }
        return false;
    }
