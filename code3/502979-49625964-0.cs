    Excel.Application excelApplication =  new Excel.Application()  // start excel and turn off msg boxes
    {
         DisplayAlerts = false,
         Visible = false
    };
    
    Excel.Workbook workBook = excelApplication.Workbooks.Open(targetFile);
    Excel.Worksheet workSheet = (Excel.Worksheet)workBook.Worksheets[1];
    
    var rDT = workSheet.Range(workSheet.Cells[monthYearNameRow, monthYearNameCol], workSheet.Cells[monthYearNameRow, maxTableColumnIndex]);
    rDT.Merge();
    rDT.Value = monthName + " " + year;
    var reportDateRowStyle = workBook.Styles.Add("ReportDateRowStyle");
    reportDateRowStyle.HorizontalAlignment = XlHAlign.xlHAlignCenter;
    reportDateRowStyle.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
    reportDateRowStyle.Font.Bold = true;
    reportDateRowStyle.Font.Size = 14;
    rDT.Style = reportDateRowStyle;
