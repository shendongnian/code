    var excel = new ExcelPackage();
    excel.File = new System.IO.FileInfo(@"C:\Temp\AnExcelFile.xlsx");
    if (excel.File.Exists)
        excel.Load(excel.File.Open(FileMode.Open));
    ExcelWorksheet ws = excel.Workbook.Worksheets.Add("Worksheet-Name");//must be unique and less than 31 characters long
    ws.Cells[26, 1].LoadFromDataTable(dt, true); //loading from DataTable, the 2.Parameter is PrintHeaders
    ws.Cells[26, 1].LoadFromCollection(query, true); //loading by LINQ-Query also possible
    excel.Save();
