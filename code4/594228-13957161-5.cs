    using System;
    using System.Collections.Generic;
    using DocumentFormat.OpenXml;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Spreadsheet;
    using System.Text;
    using System.IO;
    using System.Globalization;
    
    namespace ExportToExcel {
        public enum DataType {
            String,
            Integer,
            Date
        }
        public enum HorizontalAlignment {
            Left,
            Center,
            Right
        }
        public class ColumnModel {
            public DataType Type { set; get; }
            public HorizontalAlignment Alignment { set; get; }
            public string Header { set; get; }
            public bool IsRotatedHeader { set; get; }
        }
        public enum OutputCellFormat: uint {
            Text,
            Integer,
            Date,
            TextHeader,
            TextHeaderRotated,
            TextCenter,
            TextRight
        }
    
        public static class ExportToExcel {
            private static StringBuilder ConvertIntToColumnHeader (uint iCol) {
                var sb = new StringBuilder();
    
                while (iCol > 0) {
                    if (iCol <= 'Z' - 'A') // iCol=0 -> 'A', 25 -> 'Z'
                        break;
                    sb.Append(ConvertIntToColumnHeader(iCol / ('Z' - 'A' + 1) - 1));
                    iCol = iCol % ('Z' - 'A' + 1);
                }
                sb.Append((char)('A' + iCol));
    
                return sb;
            }
    
            private static string GetCellReference (uint iRow, uint iCol) {
                return ConvertIntToColumnHeader(iCol).Append(iRow).ToString();
            }
    
            private static Row CreateColumnHeaderRow (uint iRow, IList<ColumnModel> colunmModels) {
                var r = new Row { RowIndex = iRow };
    
                for (var iCol = 0; iCol < colunmModels.Count; iCol++) {
                    var styleIndex = colunmModels[iCol].IsRotatedHeader
                                         ? (UInt32Value)(uint)(OutputCellFormat.TextHeaderRotated + 1)
                                         : (UInt32Value)(uint)(OutputCellFormat.TextHeader + 1);
                    r.Append(new OpenXmlElement[] {
                        // create Cell with InlineString as a child, which has Text as a child
                        new Cell(new InlineString(new Text { Text = colunmModels[iCol].Header })) {
                            DataType = CellValues.InlineString,
                            StyleIndex = styleIndex,
                            CellReference = GetCellReference(iRow, (uint)iCol)
                        }
                    });
                }
    
                return r;
            }
    
            private static UInt32Value GetStyleIndexFromColumnModel (ColumnModel colunmModel) {
                switch (colunmModel.Type) {
                    case DataType.Integer:
                        return (uint)(OutputCellFormat.Integer) + 1;
                    case DataType.Date:
                        return (uint)(OutputCellFormat.Date) + 1;
                }
    
                switch (colunmModel.Alignment) {
                    case HorizontalAlignment.Center:
                        return (uint)(OutputCellFormat.TextCenter) + 1;
                    case HorizontalAlignment.Right:
                        return (uint)(OutputCellFormat.TextRight) + 1;
                    default:
                        return (uint)(OutputCellFormat.Text) + 1;
                }
            }
    
            private static string ConvertDateToString (string date) {
                DateTime dt;
                string text = date; // default results of conversion
                if (DateTime.TryParse(date, out dt))
                    text = dt.ToOADate().ToString(CultureInfo.InvariantCulture);
                return text;
            }
    
            private static Row CreateRow (UInt32 iRow, IList<string> data, IList<ColumnModel> colunmModels, IDictionary<string, int> sharedStrings) {
                var r = new Row { RowIndex = iRow };
                for (var iCol = 0; iCol < data.Count; iCol++) {
                    var styleIndex = (uint)(OutputCellFormat.Text) + 1;
                    if (colunmModels != null && iCol < colunmModels.Count) {
                        styleIndex = GetStyleIndexFromColumnModel(colunmModels[iCol]);
                        switch (colunmModels[iCol].Type) {
                            case DataType.Integer:
                                r.Append(new OpenXmlElement[] {
                                    // create Cell with CellValue as a child, which has Text as a child
                                    new Cell(new CellValue { Text = data[iCol] }) {
                                        StyleIndex = styleIndex,
                                        CellReference = GetCellReference(iRow, (uint)iCol)
                                    }
                                });
                                continue;
                            case DataType.Date:
                                r.Append(new OpenXmlElement[] {
                                    // create Cell with CellValue as a child, which has Text as a child
                                    new Cell(new CellValue { Text = ConvertDateToString(data[iCol]) }) {
                                        StyleIndex = styleIndex,
                                        CellReference = GetCellReference(iRow, (uint)iCol)
                                    }
                                });
                                continue;
                        }
                    }
    
                    // default format is text
                    if (!sharedStrings.ContainsKey(data[iCol])) {
                        // create Cell with InlineString as a child, which has Text as a child
                        r.Append(new OpenXmlElement[] {
                            new Cell(new InlineString(new Text { Text = data[iCol] })) {
                                DataType = CellValues.InlineString,
                                StyleIndex = styleIndex,
                                CellReference = GetCellReference(iRow, (uint)iCol)
                            }
                        });
                    }
    
                    r.Append(new OpenXmlElement[] {
                        // create Cell with CellValue as a child, which has Text as a child
                        new Cell(new CellValue { Text = sharedStrings[data[iCol]].ToString(CultureInfo.InvariantCulture) }) {
                            DataType = CellValues.SharedString,
                            StyleIndex = styleIndex,
                            CellReference = GetCellReference(iRow, (uint)iCol)
                        }
                    });
                }
    
                return r;
            }
    
            private static void FillSpreadsheetDocument (SpreadsheetDocument spreadsheetDocument, IList<ColumnModel> columnModels, string[][] data, string sheetName) {
                if (columnModels == null)
                    throw new ArgumentNullException("columnModels");
                if (data == null)
                    throw new ArgumentNullException("data");
    
                // add empty workbook and worksheet to the SpreadsheetDocument
                var workbookPart = spreadsheetDocument.AddWorkbookPart();
                var worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                var workbookStylesPart = workbookPart.AddNewPart<WorkbookStylesPart>();
    
                // create styles for the header and columns
                workbookStylesPart.Stylesheet = new Stylesheet(
                    new Fonts(
                    // Index 0 - The default font.
                        new Font(
                            new FontSize { Val = 11 },
                            new Color { Rgb = new HexBinaryValue { Value = "00000000" } },
                            new FontName { Val = "Calibri" }
                        ),
                    // Index 1 - The bold font.
                        new Font(
                            new Bold(),
                            new FontSize { Val = 11 },
                            new Color { Rgb = new HexBinaryValue { Value = "00000000" } },
                            new FontName { Val = "Calibri" }
                        )
                    ),
                    new Fills(
                    // Index 0 - required, reserved by Excel - no pattern
                        new Fill(new PatternFill { PatternType = PatternValues.None }),
                    // Index 1 - required, reserved by Excel - fill of gray 125
                        new Fill(new PatternFill { PatternType = PatternValues.Gray125 }),
                    // Index 2 - no pattern text on gray background
                        new Fill(new PatternFill {
                            PatternType = PatternValues.Solid,
                            BackgroundColor = new BackgroundColor { Indexed = 64U },
                            ForegroundColor = new ForegroundColor { Rgb = "FFD9D9D9" }
                        })
                    ),
                    new Borders(
                    // Index 0 - The default border.
                        new Border(
                            new LeftBorder(),
                            new RightBorder(),
                            new TopBorder(),
                            new BottomBorder(),
                            new DiagonalBorder()
                        ),
                    // Index 1 - Applies a Left, Right, Top, Bottom border to a cell
                        new Border(
                            new LeftBorder(new Color { Auto = true }) { Style = BorderStyleValues.Thin },
                            new RightBorder(new Color { Auto = true }) { Style = BorderStyleValues.Thin },
                            new TopBorder(new Color { Auto = true }) { Style = BorderStyleValues.Thin },
                            new BottomBorder(new Color { Auto = true }) { Style = BorderStyleValues.Thin },
                            new DiagonalBorder()
                        )
                    ),
                    new CellFormats(
                    // Index 0 - The default cell style.  If a cell does not have a style iCol applied it will use this style combination instead
                        new CellFormat {
                            NumberFormatId = (UInt32Value)0U,
                            FontId = (UInt32Value)0U,
                            FillId = (UInt32Value)0U,
                            BorderId = (UInt32Value)0U
                        },
                    // Index 1 - Alignment Left, Text
                        new CellFormat(new Alignment { Horizontal = HorizontalAlignmentValues.Left }) {
                            NumberFormatId = (UInt32Value)49U, // "@" - text format - see http://msdn.microsoft.com/en-us/library/documentformat.openxml.spreadsheet.numberingformat.aspx
                            FontId = (UInt32Value)0U,
                            FillId = (UInt32Value)0U,
                            BorderId = (UInt32Value)1U,
                            ApplyNumberFormat = true,
                            ApplyAlignment = true
                        },
                    // Index 2 - Integer Number
                        new CellFormat {
                            NumberFormatId = (UInt32Value)1U, // "0" - integer format - see http://msdn.microsoft.com/en-us/library/documentformat.openxml.spreadsheet.numberingformat.aspx
                            FontId = (UInt32Value)0U,
                            FillId = (UInt32Value)0U,
                            BorderId = (UInt32Value)1U,
                            ApplyNumberFormat = true
                        },
                    // Index 3 - Interger Date
                        new CellFormat {
                            NumberFormatId = (UInt32Value)14U, // "14" - date format mm-dd-yy - see http://msdn.microsoft.com/en-us/library/documentformat.openxml.spreadsheet.numberingformat.aspx
                            FontId = (UInt32Value)0U,
                            FillId = (UInt32Value)0U,
                            BorderId = (UInt32Value)1U,
                            ApplyNumberFormat = true
                        },
                    // Index 4 - Text for headers
                        new CellFormat(new Alignment {
                            Vertical = VerticalAlignmentValues.Center,
                            Horizontal = HorizontalAlignmentValues.Center
                        }) {
                            NumberFormatId = (UInt32Value)49U, // "@" - text format - see http://msdn.microsoft.com/en-us/library/documentformat.openxml.spreadsheet.numberingformat.aspx
                            FontId = (UInt32Value)1U,
                            FillId = (UInt32Value)2U,
                            BorderId = (UInt32Value)1U,
                            ApplyNumberFormat = true,
                            ApplyAlignment = true
                        },
                    // Index 5 - Text for headers rotated
                        new CellFormat(new Alignment {
                            Horizontal = HorizontalAlignmentValues.Center,
                            TextRotation = (UInt32Value)90U
                        }) {
                            NumberFormatId = (UInt32Value)49U, // "@" - text format - see http://msdn.microsoft.com/en-us/library/documentformat.openxml.spreadsheet.numberingformat.aspx
                            FontId = (UInt32Value)1U,
                            FillId = (UInt32Value)2U,
                            BorderId = (UInt32Value)1U,
                            ApplyNumberFormat = true,
                            ApplyAlignment = true
                        },
                    // Index 6 - Alignment Center, Text
                        new CellFormat(new Alignment { Horizontal = HorizontalAlignmentValues.Center }) {
                            NumberFormatId = (UInt32Value)49U, // "@" - text format - see http://msdn.microsoft.com/en-us/library/documentformat.openxml.spreadsheet.numberingformat.aspx
                            FontId = (UInt32Value)0U,
                            FillId = (UInt32Value)0U,
                            BorderId = (UInt32Value)1U,
                            ApplyNumberFormat = true,
                            ApplyAlignment = true
                        },
                    // Index 7 - Alignment Right, Text
                        new CellFormat(new Alignment { Horizontal = HorizontalAlignmentValues.Right }) {
                            NumberFormatId = (UInt32Value)49U, // "@" - text format - see http://msdn.microsoft.com/en-us/library/documentformat.openxml.spreadsheet.numberingformat.aspx
                            FontId = (UInt32Value)0U,
                            FillId = (UInt32Value)0U,
                            BorderId = (UInt32Value)1U,
                            ApplyNumberFormat = true,
                            ApplyAlignment = true
                        }
                    )
                );
                workbookStylesPart.Stylesheet.Save();
    
                // create and fill SheetData
                var sheetData = new SheetData();
    
                // first row is the header
                uint iRow = 1;
                sheetData.AppendChild(CreateColumnHeaderRow(iRow++, columnModels));
    
                // first of all collect all different strings
                var sharedStringTable = new SharedStringTable();
                var sharedStringIndexes = new SortedDictionary<string, int>();
                foreach (var dataRow in data)
                    for (var iCol = 0; iCol < dataRow.Length; iCol++)
                        if (iCol >= columnModels.Count || columnModels[iCol].Type != DataType.Integer) {
                            string text = columnModels[iCol].Type == DataType.Date
                                              ? ConvertDateToString(dataRow[iCol])
                                              : dataRow[iCol];
                            if (!sharedStringIndexes.ContainsKey(text)) {
                                sharedStringTable.AppendChild(new SharedStringItem(new Text(text)));
                                sharedStringIndexes.Add(text, sharedStringIndexes.Count);
                            }
                        }
    
                var shareStringPart = workbookPart.AddNewPart<SharedStringTablePart>();
                shareStringPart.SharedStringTable = sharedStringTable;
    
                shareStringPart.SharedStringTable.Save();
    
                foreach (var dataRow in data)
                    sheetData.AppendChild(CreateRow(iRow++, dataRow, columnModels, sharedStringIndexes));
    
                // add sheet data to Worksheet
                worksheetPart.Worksheet = new Worksheet(sheetData);
                worksheetPart.Worksheet.Save();
    
                // fill workbook with the Worksheet
                spreadsheetDocument.WorkbookPart.Workbook = new Workbook(
                        new FileVersion { ApplicationName = "Microsoft Office Excel" },
                        new Sheets(new Sheet {
                            Name = sheetName,
                            SheetId = (UInt32Value)1U,
                            Id = workbookPart.GetIdOfPart(worksheetPart) // generate the id for sheet
                        })
                    );
                spreadsheetDocument.WorkbookPart.Workbook.Save();
                spreadsheetDocument.Close();
            }
    
            public static void FillSpreadsheetDocument (Stream stream, ColumnModel[] columnModels, string[][] data, string sheetName) {
                using (var spreadsheetDocument = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook)) {
                    FillSpreadsheetDocument(spreadsheetDocument, columnModels, data, sheetName);
                }
            }
        }
        class Program {
            static void Main () {
                var data = new[] {
                    new [] {"Tom",       "30", "x", "",  "1974-06-16"},
                    new [] {"Margarita", "34", "x", "x", "1978-10-02"},
                    new [] {"Bob",       "7",  "",  "",  "2005-06-26"},
                    new [] {"Oleg",      "48", "x", "x", "1964-09-11"},
                    new [] {"Frank",     "29", "",  "x", "1983-01-28"}
                };
                using (var stream = new FileStream("Test.xlsx", FileMode.Create)) {
                    ExportToExcel.FillSpreadsheetDocument(stream,
                        new[] {
                            new ColumnModel { Type = DataType.String, Alignment = HorizontalAlignment.Left, Header = "Name" },
                            new ColumnModel { Type = DataType.Integer, Header = "Age" },
                            new ColumnModel { Type = DataType.String, Header = "Is Married", Alignment = HorizontalAlignment.Center, IsRotatedHeader = true },
                            new ColumnModel { Type = DataType.String, Header = "Has Children", Alignment = HorizontalAlignment.Center, IsRotatedHeader = true },
                            new ColumnModel { Type = DataType.Date, Header = "Birthday", Alignment = HorizontalAlignment.Left }
                        },
                        data,
                        "Friends");
                }
            }
        }
    }
