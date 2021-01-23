    public static DataTable ReadIntoDatatableFromExcel(string newFilePath)
            {
                /*Creating a table with 20 columns*/
                var dt = CreateProviderRvenueSharingTable();
    
                try
                {
                    /*using stream so that if excel file is in another process then it can read without error*/
                    using (Stream stream = new FileStream(newFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(stream, false))
                        {
                            var workbookPart = spreadsheetDocument.WorkbookPart;
                            var workbook = workbookPart.Workbook;
    
                            /*get only unhide tabs*/
                            var sheets = workbook.Descendants<Sheet>().Where(e => e.State == null);
    
                            foreach (var sheet in sheets)
                            {
                                var worksheetPart = (WorksheetPart)workbookPart.GetPartById(sheet.Id);
    
                                /*Remove empty sheets*/
                                List<Row> rows = worksheetPart.Worksheet.Elements<SheetData>().First().Elements<Row>()
                                    .Where(r => r.InnerText != string.Empty).ToList();
    
                                if (rows.Count > 1)
                                {
                                    OpenXmlReader reader = OpenXmlReader.Create(worksheetPart);
    
                                    int i = 0;
                                    int BTR = 0;/*Break the reader while empty rows are found*/
    
                                    while (reader.Read())
                                    {
                                        if (reader.ElementType == typeof(Row))
                                        {
                                            /*ignoring first row with headers and check if data is there after header*/
                                            if (i < 2)
                                            {
                                                i++;
                                                continue;
                                            }
    
                                            reader.ReadFirstChild();
    
                                            DataRow row = dt.NewRow();
    
                                            int CN = 0;
    
                                            if (reader.ElementType == typeof(Cell))
                                            {
                                                do
                                                {
                                                    Cell c = (Cell)reader.LoadCurrentElement();
    
                                                    /*reader skipping blank cells so data is getting worng in datatable's rows according to header*/
                                                    if (CN != 0)
                                                    {
                                                        int cellColumnIndex =
                                                            ExcelHelper.GetColumnIndexFromName(
                                                                ExcelHelper.GetColumnName(c.CellReference));
    
                                                        if (cellColumnIndex < 20 && CN < cellColumnIndex - 1)
                                                        {
                                                            do
                                                            {
                                                                row[CN] = string.Empty;
                                                                CN++;
                                                            } while (CN < cellColumnIndex - 1);
                                                        }
                                                    }
    
                                                    /*stopping execution if first cell does not have any value which means empty row*/
                                                    if (CN == 0 && c.DataType == null && c.CellValue == null)
                                                    {
                                                        BTR++;
                                                        break;
                                                    }
    
                                                    string cellValue = GetCellValue(c, workbookPart);
                                                    row[CN] = cellValue;
                                                    CN++;
    
                                                    /*if any text exists after T column (index 20) then skip the reader*/
                                                    if (CN == 20)
                                                    {
                                                        break;
                                                    }
                                                } while (reader.ReadNextSibling());
                                            }
    
                                            /*reader skipping blank cells so fill the array upto 19 index*/
                                            while (CN != 0 && CN < 20)
                                            {
                                                row[CN] = string.Empty;
                                                CN++;
                                            }
    
                                            if (CN == 20)
                                            {
                                                dt.Rows.Add(row);
                                            }
                                        }
                                        /*escaping empty rows below data filled rows after checking 5 times */
                                        if (BTR > 5)
                                            break;
                                    }
                                    reader.Close();
                                }                            
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return dt;
            }
    
      private static string GetCellValue(Cell c, WorkbookPart workbookPart)
            {
                string cellValue = string.Empty;
                if (c.DataType != null && c.DataType == CellValues.SharedString)
                {
                    SharedStringItem ssi =
                        workbookPart.SharedStringTablePart.SharedStringTable
                            .Elements<SharedStringItem>()
                            .ElementAt(int.Parse(c.CellValue.InnerText));
                    if (ssi.Text != null)
                    {
                        cellValue = ssi.Text.Text;
                    }
                }
                else
                {
                    if (c.CellValue != null)
                    {
                        cellValue = c.CellValue.InnerText;
                    }
                }
                return cellValue;
            }
    
    public static int GetColumnIndexFromName(string columnNameOrCellReference)
            {
                int columnIndex = 0;
                int factor = 1;
                for (int pos = columnNameOrCellReference.Length - 1; pos >= 0; pos--)   // R to L
                {
                    if (Char.IsLetter(columnNameOrCellReference[pos]))  // for letters (columnName)
                    {
                        columnIndex += factor * ((columnNameOrCellReference[pos] - 'A') + 1);
                        factor *= 26;
                    }
                }
                return columnIndex;
            }
    
            public static string GetColumnName(string cellReference)
            {
                /* Advance from L to R until a number, then return 0 through previous position*/
                for (int lastCharPos = 0; lastCharPos <= 3; lastCharPos++)
                    if (Char.IsNumber(cellReference[lastCharPos]))
                        return cellReference.Substring(0, lastCharPos);
    
                throw new ArgumentOutOfRangeException("cellReference");
            }
