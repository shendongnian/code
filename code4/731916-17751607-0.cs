        Microsoft.Office.Interop.Excel.Range range = sheet.UsedRange;
        Microsoft.Office.Interop.Excel.Range cell = range.Cells[1][1];
        Microsoft.Office.Interop.Excel.Borders border = cell.Borders;
        border[XlBordersIndex.xlEdgeLeft].LineStyle =
            Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
        border[XlBordersIndex.xlEdgeTop].LineStyle =
            Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
        border[XlBordersIndex.xlEdgeBottom].LineStyle =
            Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
        border[XlBordersIndex.xlEdgeRight].LineStyle =
            Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
