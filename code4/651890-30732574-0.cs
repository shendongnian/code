    using Microsoft.Office.Interop.Excel;
    MyClass{
    ...
        var app = new Application { Visible = true, ScreenUpdating = true, DisplayAlerts = false }; 
        Workbook book = app.Workbooks.Open(path); //path is the fullFileName as string
        Worksheet sheet = book.Worksheets[1];
        Range range = sheet.get_Range("A1", "A1");
        range.Select();
        range.HorizontalAlignment = Constants.xlCenter;
        range.VerticalAlignment = Constants.xlBottom;
        range.WrapText = true;
        range.Orientation = 0;
        range.AddIndent = false;
        range.IndentLevel = 0;
        range.ShrinkToFit = false;
        range.ReadingOrder = Constants.xlContext;
        range.MergeCells = false;
    }
