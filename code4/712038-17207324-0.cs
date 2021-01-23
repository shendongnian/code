    using (SpreadsheetDocument ssd = SpreadsheetDocument.Open(Server.MapPath(@"\ExcelPackageTemplate.xlsx"), true))
    {
        WorkbookPart wbPart = ssd.WorkbookPart;
        WorksheetPart worksheetPart = wbPart.WorksheetParts.First();
    
        SheetData sheetdata = worksheetPart.Worksheet.GetFirstChild<SheetData>();
        string[] headerColumns = new string[] { dt.Columns[0].ColumnName, dt.Columns[1].ColumnName, dt.Columns[2].ColumnName };
        DocumentFormat.OpenXml.Spreadsheet.Row r = new DocumentFormat.OpenXml.Spreadsheet.Row();
        DocumentFormat.OpenXml.Spreadsheet.Cell cell = new DocumentFormat.OpenXml.Spreadsheet.Cell();
        int RowIndexer = 1;
        int ColumnIndexer = 1;
                    
        r.RowIndex = (UInt32)RowIndexer;
        foreach (DataColumn dc in dt.Columns)
        {
            cell = new DocumentFormat.OpenXml.Spreadsheet.Cell();
            cell.CellReference = ColumnName(ColumnIndexer) + RowIndexer;
            cell.DataType = CellValues.InlineString;
            cell.InlineString = new InlineString(new Text(dc.ColumnName.ToString()));
            // consider using cell.CellValue. Then you don't need to use InlineString.
            // Because it seems you're not using any rich text so you're just bloating up
            // the XML.
    
            r.AppendChild(cell);
    
            ColumnIndexer++;
        }
        // here's the missing part you needed
        sheetdata.Append(r);
    
        RowIndexer = 2;
        foreach (DataRow dr in dt.Rows)
        {
            r = new DocumentFormat.OpenXml.Spreadsheet.Row();
            r.RowIndex = (UInt32)RowIndexer;
            // this follows the same starting column index as your column header.
            // I'm assuming you start with column 1. Change as you see fit.
            ColumnIndexer = 1;
            foreach (object value in dr.ItemArray)
            {
                cell = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                // I moved it here so it's consistent with the above part
                // Also, the original code was using the row index to calculate
                // the column name, which is weird.
                cell.CellReference = ColumnName(ColumnIndexer) + RowIndexer;
                cell.DataType = CellValues.InlineString;
                cell.InlineString = new InlineString(new Text(value.ToString()));
                            
                r.AppendChild(cell);
                ColumnIndexer++;
            }
            RowIndexer++;
    
            // missing part
            sheetdata.Append(r);
        }
                    
        worksheetPart.Worksheet.Save();
        wbPart.Workbook.Save();
        ssd.Close();
    }
