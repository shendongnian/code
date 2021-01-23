    using Excel = Microsoft.Office.Interop.Excel;
    using System.Reflection;
    Missing noValue = Missing.Value;
    Excel.Range conditionalCell;
    foreach (Excel.Range usedRange in ws.UsedRange.Rows)
    {
        conditionalCell = usedRange.Cells[noValue, 2] as Excel.Range;
        if (Convert.ToInt32(conditionalCell.Value2) >= 3)
        {
            usedRange.Cells.Interior.Color = Excel.XlRgbColor.rgbRed;
        }
    }
