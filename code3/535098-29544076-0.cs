            /// <summary>
            /// Return si value based on xml cell id number
            /// </summary>
            /// <param name="workbookPart"></param>
            /// <param name="id"></param>
            /// <returns>SharedStringItem for interpretation</returns>
            public static SharedStringItem GetSharedStringItemById(WorkbookPart workbookPart, int id)
            {
                return workbookPart.SharedStringTablePart.SharedStringTable.Elements<SharedStringItem>().ElementAt(id);
            }
    
            /// <summary>
            /// Return value from the cell based on the cell's information (innards and/or id)
            /// </summary>
            /// <param name="cell">spreadhseet cell</param>
            /// <param name="workbookPart">work book from uploaded file</param>
            /// <returns>string value of the cell</returns>
            public static string GetValueFromCell(Cell cell, WorkbookPart workbookPart)
            {
                int id;
                string cellValue = cell.InnerText;
    
                if (cellValue.Trim().Length > 0)
                {
                    if (cell.DataType != null)
                    {
                        switch (cell.DataType.Value)
                        {
                            case CellValues.SharedString:
    
                                Int32.TryParse(cellValue, out id);
                                SharedStringItem item = GetSharedStringItemById(workbookPart, id);
                                if (item.Text != null)
                                {
                                    cellValue = item.Text.Text;
                                }
                                else if (item.InnerText != null)
                                {
                                    cellValue = item.InnerText;
                                }
                                else if (item.InnerXml != null)
                                {
                                    cellValue = item.InnerXml;
                                }
                                break;
    
                            case CellValues.Boolean:
                                switch (cellValue)
                                {
                                    case "0":
                                        cellValue = "FALSE";
                                        break;
                                    default:
                                        cellValue = "TRUE";
                                        break;
                                }
                                break;
                        }
                    }
    
                    else
                    {
                        int excelDate;
                        if (Int32.TryParse(cellValue, out excelDate))
                        {
    
                            var styleIndex = (int)cell.StyleIndex.Value;
    
                            var cellFormats = workbookPart.WorkbookStylesPart.Stylesheet.CellFormats;
                            var numberingFormats = workbookPart.WorkbookStylesPart.Stylesheet.NumberingFormats;
                            var cellFormat = (CellFormat)cellFormats.ElementAt(styleIndex);
    
                            if (cellFormat.NumberFormatId != null)
                            {
    
                                var numberFormatId = cellFormat.NumberFormatId.Value;
                                var numberingFormat = numberingFormats.Cast<NumberingFormat>().SingleOrDefault(f => f.NumberFormatId.Value == numberFormatId);
    
                                if (numberingFormat != null && numberingFormat.FormatCode.Value.Contains("/yy")) //TODO here i should think of locales
                                {
                                    DateTime dt = DateTime.FromOADate(excelDate);
                                    cellValue = dt.ToString("MM/dd/yyyy");
                                }
                            }
                        }
                    }
                }
                return cellValue;
            }
