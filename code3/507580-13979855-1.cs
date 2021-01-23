    public class SimplePivotTable : IPivotTableCreator
    {
        List<string> _GroupByColumns;
        List<string> _SummaryColumns;
        /// <summary>
        /// Constructor
        /// </summary>
        public SimplePivotTable(string[] groupByColumns, string[] summaryColumns)
        {
            _GroupByColumns = new List<string>(groupByColumns);
            _SummaryColumns = new List<string>(summaryColumns);
        }
        /// <summary>
        /// Call-back handler that builds simple PivatTable in Excel
        /// http://stackoverflow.com/questions/11650080/epplus-pivot-tables-charts
        /// </summary>
        public void CreatePivotTable(OfficeOpenXml.ExcelPackage pkg, string tableName, string pivotRangeName)
        {
            string pageName = "Pivot-" + tableName.Replace(" ", "");
            var wsPivot = pkg.Workbook.Worksheets.Add(pageName);
            pkg.Workbook.Worksheets.MoveBefore(PageName, tableName);
            var dataRange = pkg.Workbook./*Worksheets[tableName].*/Names[pivotRangeName];
            var pivotTable = wsPivot.PivotTables.Add(wsPivot.Cells["C3"], dataRange, "Pivot_" + tableName.Replace(" ", ""));
            pivotTable.ShowHeaders = true;
            pivotTable.UseAutoFormatting = true;
            pivotTable.ApplyWidthHeightFormats = true;
            pivotTable.ShowDrill = true;
            pivotTable.FirstHeaderRow = 1;  // first row has headers
            pivotTable.FirstDataCol = 1;    // first col of data
            pivotTable.FirstDataRow = 2;    // first row of data
            foreach (string row in _GroupByColumns)
            {
                var field = pivotTable.Fields[row];
                pivotTable.RowFields.Add(field);
                field.Sort = eSortType.Ascending;
            }
            foreach (string column in _SummaryColumns)
            {
                var field = pivotTable.Fields[column];
                ExcelPivotTableDataField result = pivotTable.DataFields.Add(field);
            }
            pivotTable.DataOnRows = false;
        }
    }
