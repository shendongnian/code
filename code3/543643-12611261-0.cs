    var cellValues = from cell in row.Descendants<Cell>()
                        select cell;
    foreach (var cell in cellValues)
    {
        if(cell.DataType != null 
            && cell.DataType.HasValue 
            && cell.DataType == CellValues.SharedString
            && int.Parse(cell.CellValue.InnerText) < sharedString.ChildElements.Count)
        {
            DoSomething(sharedString.ChildElements[int.Parse(cell.CellValue.InnerText)].InnerText);
        }
        else
        {
            DoSomething(cell.CellValue.InnerText);
        }
    }
