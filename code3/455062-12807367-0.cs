    using (var package = new ExcelPackage(fileStream))
    {
        // Get the workbook in the file
        var workbook = package.Workbook;
        if (workbook != null && workbook.Worksheets.Any())
        {
            // Get the first worksheet
            var sheet = workbook.Worksheets.First();
            // Get header values
            var column1Header = sheet.Cells["A1"].GetValue<string>();
            var column2Header = sheet.Cells["B1"].GetValue<string>();
            // "A2:A" means "starting from A2 (1st col, 2nd row),
            // get me all populated cells in Column A" (yes, unusual range syntax)
            var firstColumnRows = sheet.Cells["A2:A"];
            // Loop through rows in the first column, get values based on offset
            foreach (var cell in firstColumnRows)
            {
                var column1CellValue = cell.GetValue<string>();
                var column2CellValue = cell.Offset(0, 1).GetValue<string>();
            }
        }
    }
