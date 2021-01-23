     using Excel = Microsoft.Office.Interop.Excel;
     ...
            Excel.Range selection = ThisAddIn.Application.Selection;
            Excel.Borders borders = selection.Borders;
            Excel.Border border = borders[Excel.XlBordersIndex.xlEdgeLeft];
            if (border.LineStyle == Excel.XlLineStyle.xlContinuous)
            {
            }
            if (border.LineStyle == Excel.XlLineStyle.xlDouble)
            {
            }
            if (border.Weight == Excel.XlBorderWeight.xlThick)
            {
            }
