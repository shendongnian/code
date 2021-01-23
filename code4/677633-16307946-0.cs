    using System;
    using System.Data;
    using System.IO;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Spreadsheet;
    using DocumentFormat.OpenXml;
    
    namespace TestOpenXmlSDK
    {
        class Excel
        {
            public void convertToExcel(string padXml)
            {
                //maak dataset en vul met ingevoerde xml
                DataSet dsXML = new DataSet();
                dsXML.ReadXml(padXml);
                DataTable tblXML = dsXML.Tables[2];
    
                //opslaan
                string padXlsx = Path.GetDirectoryName(padXml) + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + ".xlsx";
    
                //spreadsheet
                using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create(padXlsx, SpreadsheetDocumentType.Workbook))
                {
                    WorkbookPart workbookPart = spreadsheetDocument.AddWorkbookPart();
                    WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                    Workbook workbook = new Workbook();
                    FileVersion fv = new FileVersion();
                    fv.ApplicationName = "Microsoft Office Excel";
                    Worksheet worksheet = new Worksheet();
                    SheetData sheetData = new SheetData();
    
                    //styles
                    WorkbookStylesPart stylesPart = spreadsheetDocument.WorkbookPart.AddNewPart<WorkbookStylesPart>();
                    stylesPart.Stylesheet = new Stylesheet();
                    stylesPart.Stylesheet.Save();
    
                    //kolommen
                    DocumentFormat.OpenXml.Spreadsheet.Columns columns = new Columns();
                    for (int i = 1; i < tblXML.Columns.Count; i++)
                    {
                        Column column = new Column();
                        column.Min = Convert.ToUInt32(i);
                        column.Max = Convert.ToUInt32(i + 1);
                        int lengte = tblXML.Rows[13][i - 1].ToString().Length;
                        if (lengte < 10)
                        {
                            lengte = 10;
                        }
                        else if (lengte > 35)
                        {
                            lengte = 35;
                        }
                        else
                        {
                            lengte += 5;
                        }
                        column.Width = lengte;
                        column.BestFit = true;
                        columns.Append(column);
                    }
                    worksheet.Append(columns);
    
                    //header
                    Row header = new Row();
                    header.RowIndex = (UInt32)1;
    
                    foreach (DataColumn columnInDataTable in tblXML.Columns)
                    {
                        Cell headerCell = createTextCell(tblXML.Columns.IndexOf(columnInDataTable) + 1, 1, columnInDataTable.ColumnName);
                        //headerCell.StyleIndex = 1;
                        header.AppendChild(headerCell);
                    }
                    sheetData.AppendChild(header);
    
                    // Add a row to the cell table.
                    for (int i = 1; i < tblXML.Rows.Count; i++)
                    {
                        Row row;
                        row = new Row() { RowIndex = Convert.ToUInt32(i) + 1 };
    
                        for (int j = 0; j < tblXML.Columns.Count; j++)
                        {
                            Cell newCell = new Cell()
                            {
                                CellReference = getColumnName(i),
                                DataType = CellValues.Number,
                                //StyleIndex = 6,
                                CellValue = new CellValue(tblXML.Rows[i][j].ToString()),
                            };
                            row.Append(newCell);
                        }
                        sheetData.Append(row);
                    }
    
                    //autofilter
                    string laatsteKolom = zoekLaatsteKolom(tblXML);
                    AutoFilter autoFilter = new AutoFilter();
                    autoFilter.Reference = "A1:" + laatsteKolom + "1";
    
                    //aantal auto's
                    Row aantalAutosRow = new Row();
                    aantalAutosRow.RowIndex = Convert.ToUInt32((tblXML.Rows.Count) + 2);
    
                    Cell aantalAutosCell = new Cell();
                    aantalAutosCell.CellReference = getColumnName(1);
                    aantalAutosCell.CellValue = new CellValue("Hoi");
                    aantalAutosCell.DataType = CellValues.String;
                    //CellFormula berekenAantalAutos = new CellFormula();
                    //berekenAantalAutos.Text = "=COUNTA(A2:A" + tblXML.Rows.Count.ToString();
    
                    //aantalAutosCell.Append(berekenAantalAutos);
                    aantalAutosRow.Append(aantalAutosCell);
                    sheetData.Append(aantalAutosRow);
    
                    worksheet.Append(sheetData);
                    worksheet.Append(autoFilter);
                    worksheetPart.Worksheet = worksheet;
                    worksheetPart.Worksheet.Save();
    
                    Sheets sheets = new Sheets();
                    Sheet sheet = new Sheet();
                    sheet.Name = "Voorraad";
                    sheet.SheetId = 1;
                    sheet.Id = workbookPart.GetIdOfPart(worksheetPart);
                    sheets.Append(sheet);
                    workbook.Append(fv);
                    workbook.Append(sheets);
    
                    spreadsheetDocument.WorkbookPart.Workbook = workbook;
                    spreadsheetDocument.WorkbookPart.Workbook.Save();
                    spreadsheetDocument.Close();
                }
            }
    
            //kolom naam (letter) ophalen
            private string getColumnName(int columnIndex)
            {
                int dividend = columnIndex;
                string columnName = String.Empty;
                int modifier;
    
                while (dividend > 0)
                {
                    modifier = (dividend - 1) % 26;
                    columnName =
                        Convert.ToChar(65 + modifier).ToString() + columnName;
                    dividend = (int)((dividend - modifier) / 26);
                }
    
                return columnName;
            }
    
            private Cell createTextCell(int columnIndex, int rowIndex, object cellValue)
            {
                Cell cell = new Cell();
    
                cell.DataType = CellValues.InlineString;
                cell.CellReference = getColumnName(columnIndex) + rowIndex;
    
                InlineString inlineString = new InlineString();
                Text t = new Text();
    
                t.Text = cellValue.ToString();
                inlineString.AppendChild(t);
                cell.AppendChild(inlineString);
    
                return cell;
            }
    
            string zoekLaatsteKolom(DataTable tblXML)
            {
                string kolom;
                kolom = getColumnName(tblXML.Columns.Count);
                return kolom;
            }
        }
    }
    
        
