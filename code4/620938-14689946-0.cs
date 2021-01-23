    ExcelPackage ep = new ExcelPackage(new FileStream(path, FileMode.Open, FileAccess.Read));
    var sheet = ep.Workbook.Worksheets[1];
    foreach (var cell in sheet.Cells[sheet.Dimension.Address])
    {
        var txt = cell.Text;
        var font = cell.Style.Font;
        if (!font.Bold || font.Italic || font.UnderLine)
            txt = "";
        var borderBottom = cell.Style.Border.Bottom.Style;
        var borderTop = cell.Style.Border.Top.Style;
        var borderLeft = cell.Style.Border.Left.Style;
        var borderRight = cell.Style.Border.Right.Style;
        // ...
    }
