    using Excel = Microsoft.Office.Interop.Excel;
    using System.Globalization;
    using System.Threading;
    using System.Data;
    protected void ExportExcel(DataTable dt)
    {
        if (dt == null || dt.Rows.Count == 0) return;
    
        var xlApp = new Excel.Application();
        //Is this used?
        CultureInfo CurrentCI = Thread.CurrentThread.CurrentCulture;
    
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
    
        Excel.Workbooks workbooks = xlApp.Workbooks;
    
        Excel.Range range
    
        Excel.Workbook workbook = workbooks.Add();
        Excel.Worksheet worksheet = workbook.Worksheets[1];
    
        long totalCount = dt.Rows.Count;
        long rowRead = 0;
        float percent = 0;
    
        for (var i = 0; i < dt.Columns.Count; i++)
        {
            worksheet.Cells[1, i + 1] = dt.Columns[i].ColumnName;
    
            range = worksheet.Cells[1, i + 1];
            range.Interior.ColorIndex = 15;
            range.Font.Bold = true;
        }
    
        for (var r = 0; r < dt.Rows.Count; r++)
        {
            for (var i = 0; i < dt.Columns.Count; i++)
            {
                worksheet.Cells[r + 2, i + 1] = dt.Rows[r][i].ToString();
            }
    
            rowRead++;
            //is this used?
            percent = ((float)(100 * rowRead)) / totalCount;
        }    
        Microsoft.Office.Interop.Excel.Range columns = worksheet.UsedRange.Columns;
        columns.AutoFit();
        worksheet.Rows[1].Insert();
        Excel.Range newRow = worksheet.Rows[1];
        Excel.Range newCell = newRow.Cells[1];
        newCell.Value = DateTime.Now.ToString("yyyy-MM-dd");
        xlApp.Visible = true;
    }
