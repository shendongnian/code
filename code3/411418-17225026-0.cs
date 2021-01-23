    string fileName = System.Windows.Forms.Application.StartupPath + "\\Resources\\SUPPLIERDECISIONKEYLIST.xlsx";
    using (var pck = new OfficeOpenXml.ExcelPackage())
    {
    using (var stream = File.OpenRead(fileName))
    {
    pck.Load(stream);
    }
    var ws = pck.Workbook.Worksheets[SheetNo];
