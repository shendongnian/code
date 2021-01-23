    public DataTable ToDataTable(SpreadsheetDocument spreadsheet, string worksheetName)
    {
        var workbookPart = spreadsheet.WorkbookPart;
    
        var sheet = workbookPart
            .Workbook
            .Descendants<Sheet>()
            .FirstOrDefault(s => s.Name == worksheetName);
    
        var worksheetPart = sheet == null
            ? null
            : workbookPart.GetPartById(sheet.Id) as WorksheetPart;
    
        var dataTable = new DataTable();
    
        if (worksheetPart != null)
        {
            var sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();
    
            foreach (Row row in sheetData.Descendants<Row>())
            {
                var values = row
                    .Descendants<Cell>()
                    .Select(cell =>
                    {
                        var value = cell.CellValue.InnerXml;
                        if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
                        {
                            value = workbookPart
                                .SharedStringTablePart
                                .SharedStringTable
                                .ChildElements[int.Parse(value)]
                                .InnerText;
                        }
                        return (object)value;
                    })
                    .ToArray();
    
                dataTable.Rows.Add(values);
            }
        }
    
        return dataTable;
    }
