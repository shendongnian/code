    public void ExportToExcel(IEnumerable<Employee> employees, FileInfo targetFile)
    {
        using (var excelFile = new ExcelPackage(targetFile))
        {
            var worksheet = excelFile.Workbook.Worksheets.Add("Sheet1");
            worksheet.Cells["A1"].LoadFromCollection(Collection: employees, PrintHeaders: true);
            excelFile.Save();
        }
    }
