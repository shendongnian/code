    using OfficeOpenXml;
    using (ExcelPackage outPackage = new ExcelPackage(YOUR_DESTINATION_FILENAME))
    {
        // Add new worksheet
        ExcelWorksheet destWorkSheet = outPackage.Workbook.Worksheets.Add("Spreadsheet name");
        // Draw header
        destWorksheet.Cells[1, 1].Value = "Header 1";
        destWorksheet.Cells[1, 2].Value = "Header 2";
        // Loop through your data and add rows
        for (int i = 0; i < YOURDATA.Count; i++)
        {
            destWorkSheet.Cells[i+2, 1].Value = YOUR_DATA_1;
            destWorkSheet.Cells[i+2, 2].Value = YOUR_DATA_2;
        }
        // Save spreadsheet
        outPackage.Save();
    }
