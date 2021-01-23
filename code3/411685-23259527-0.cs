    private void exportDocument(string FilePath, DataTable sourceTable)
        {
            WorkbookPart wBookPart = null;
            DataSet tableSet = getDataSet(sourceTable);//getDataSet is my local function which is used to split a datatable into some datatable based on limited row I've declared.
            using (SpreadsheetDocument spreadsheetDoc = SpreadsheetDocument.Create(FilePath, SpreadsheetDocumentType.Workbook))
            {
                wBookPart = spreadsheetDoc.AddWorkbookPart();
                wBookPart.Workbook = new Workbook();
                uint sheetId = 1;
                spreadsheetDoc.WorkbookPart.Workbook.Sheets = new Sheets();
                Sheets sheets = spreadsheetDoc.WorkbookPart.Workbook.GetFirstChild<Sheets>();
               
                foreach (DataTable table in tableSet.Tables)
                {
                    WorksheetPart wSheetPart = wBookPart.AddNewPart<WorksheetPart>();
                    Sheet sheet = new Sheet() { Id = spreadsheetDoc.WorkbookPart.GetIdOfPart(wSheetPart), SheetId = sheetId, Name = "mySheet" + sheetId };
                    sheets.Append(sheet);
                    SheetData sheetData = new SheetData();
                    wSheetPart.Worksheet = new Worksheet(sheetData);
                    Row headerRow = new Row();
                    foreach (DataColumn column in sourceTable.Columns)
                    {
                        Cell cell = new Cell();
                        cell.DataType = CellValues.String;
                        cell.CellValue = new CellValue(column.ColumnName);
                        headerRow.AppendChild(cell);
                    }
                    sheetData.AppendChild(headerRow);
                    foreach (DataRow dr in table.Rows)
                    {
                        Row row = new Row();
                        foreach (DataColumn column in table.Columns)
                        {
                            Cell cell = new Cell();
                            cell.DataType = CellValues.String;
                            cell.CellValue = new CellValue(dr[column].ToString());
                            row.AppendChild(cell);
                        }
                        sheetData.AppendChild(row);
                    }
                    sheetId++;
                }                                
            }
        }
