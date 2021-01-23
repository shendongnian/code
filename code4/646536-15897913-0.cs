    public static List<ExcelColumn> GetColumns(ExcelWorksheet wks, int startColNum, int endColNum) {
        int d = startColNum;
        List<ExcelColumn> cols = new List<ExcelColumn>();
        while (d <= endColNum) {
            cols.Add(wks.Column(d));
            d++;
        }
        return cols;
    }
    public static ExcelRange GetColumnCells(ExcelWorksheet wks, int startColNum, int endColNum) {
        string startColName = GetColumnName(startColNum);
        string endColName = GetColumnName(endColNum);
        return wks.Cells[startColName + ":" + endColName];
    }
    public static string GetColumnName(int colNum) {
        int d, m;
        string name = String.Empty;
        d = colNum;
        while (d > 0) {
            m = (d - 1) % 26;
            name = ((char)(65 + m)) + name;
            d = (d - m) / 26;
        }
        return name;
    }
