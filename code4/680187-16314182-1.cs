    public static string GetCellValue(WorkbookPart wbPart, Cell cell)
    {
        string value = string.Empty;
        if (cell != null && cell.CellValue != null)
        {
            value = cell.InnerText;
            if (cell.DataType != null)
            {
                switch (cell.DataType.Value)
                {
                    case CellValues.SharedString:
                        var stringTable = wbPart.GetPartsOfType<SharedStringTablePart>().FirstOrDefault();
                        if (stringTable != null)
                        {
                            value = stringTable.SharedStringTable.ElementAt(int.Parse(value)).InnerText;
                        }
                        break;
    
                    case CellValues.Boolean:
                        if (value == "0")
                            value = "FALSE";
                        else
                            value = "TRUE";
    
                        break;
                }
            }
        }
        return value;
    }
   
    string value = GetCellValue(wbPart,cell);
    var date = DateTime.FromOADate(double.Parse(value));
