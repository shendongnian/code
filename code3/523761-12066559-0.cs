    using (ExcelPackage ep = new ExcelPackage(AbsolutePathAndFileName))
    {
        ExcelWorksheet worksheet = ep.Workbook.Worksheets.Add("Worksheet1");
        worksheet.Cells["A1"].LoadFromDataTable(TheDataTable, true); 
        worksheet.Cells["F4"].BackgroundColor.SetColor(Color.Red);
        ep.Save();
    }
