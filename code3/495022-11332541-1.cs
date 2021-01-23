    ExcelWorksheet sheet = _openXmlPackage.Workbook.Worksheets["SheetName"];
    using (ExcelNamedRange namedRange = sheet.Names["RangeName"])
    {
        for (int rowIndex = Start.Row; rowIndex <= namedRange.End.Row; rowIndex++)
        {
            for (int columnIndex = namedRange.Start.Column; columnIndex <= namedRange.End.Column; columnIndex++)
            {
                sheet.Cells[rowIndex, columnIndex].Value = "no more hair pulling";                        
            }
        }
    }
