    using Excel = Microsoft.Office.Interop.Excel;
    
    Excel.Range pRange = Globals.ThisAddIn.Application.ActiveCell;
    pRange.Borders.Color = 0x0000FF; // an RGB value in hex
    pRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
