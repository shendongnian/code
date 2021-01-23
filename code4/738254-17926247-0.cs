    var sheetData = workSheet.Worksheet.GetFirstChild<SheetData>();
    Column firstColumn = sheetData.Elements<Column>().First();
    var newCol = firstColumn.CloneNode(true) as Column;
    firstColumn.InsertBeforeSelf<Column>(newCol);
    
    foreach(Cell cell in newCol.Elements<Cell>())
    {
        cell.Cellvalue = new CellValue(<Value>);
    }
