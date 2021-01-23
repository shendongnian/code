    FileStream fs = new FileStream(@"\export.xlsx", FileMode.Open);
    XSSFWorkbook wb = new XSSFWorkbook(fs);
    ISheet sheet = wb.GetSheetAt(0);
    // GetValue here
    string text = getValueFromCell(sheet.GetRow(row).GetCell(1));
    
    public string getValueFromCell(ICell cell) {
                string output ="";
                if (cell != null)
                {
                    switch (cell.CellType)
                    {
                        case CellType.String:
                            output = cell.StringCellValue;
                            break;
                        case CellType.Numeric:
                            //dataRow[j] = cell.NumericCellValue;
                            output = cell.NumericCellValue.ToString();
                            break;
                        case CellType.Boolean:
                            output = cell.BooleanCellValue.ToString();
                            //dataRow[j] = cell.BooleanCellValue;
                            break;
                        default:
                            output = "";
                            break;
                    }
                }
                return output;
            }
