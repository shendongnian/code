    using (var xls = new ExcelPackage())
    {
        var ws = xls.Workbook.Worksheets.Add("Some Name");
        
        //**Add Column Names to worksheet!**
        //**Add data to worksheet!**
        const double minWidth = 0.00;
        const double maxWidth = 50.00;
        ws.Cells.AutoFitColumns(minWidth, maxWidth);
        return pkg.GetAsByteArray();
    }
