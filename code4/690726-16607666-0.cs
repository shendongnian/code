    public void InsertDataTableIntoExcel(SpreadsheetDocument _excelDoc, SheetData    SheetData,  DataTable excelData, int rowIndex = 1)
        {
            if (_excelDoc != null && SheetData != null)
            {
                if (excelData.Rows.Count > 0)
                {
                    try
                    {
                        uint lastRowIndex = (uint)rowIndex;
                        for (int row = 0; row < excelData.Rows.Count; row++)
                        {
                            Row dataRow = GetRow(lastRowIndex, true);
                            for (int col = 0; col < excelData.Columns.Count; col++)
                            {
                                Cell cell = GetCell(dataRow, col + 1, lastRowIndex);
                              
                                string objDataType = excelData.Rows[row][col].GetType().ToString();
                                //Add text to text cell
                                if (objDataType.Contains(TypeCode.Int32.ToString()) || objDataType.Contains(TypeCode.Int64.ToString()) || objDataType.Contains(TypeCode.Decimal.ToString()))
                                {
                                    cell.DataType = new EnumValue<CellValues>(CellValues.Number);
                                    cell.CellValue = new CellValue(objData.ToString());
                                }
                                else
                                {
                                    cell.CellValue = new CellValue(objData.ToString());
                                    cell.DataType = new EnumValue<CellValues>(CellValues.String);
                                }
                            }
                            lastRowIndex++;
                        }
                    }
                    catch (OpenXmlPackageException ex)
                    {
                        throw ex;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                else
                {
                    OpenXmlPackageException openEx = new OpenXmlPackageException("No data from datatable");
                    throw openEx;
                }
            }
            else
            {
                OpenXmlPackageException openEx = new OpenXmlPackageException("Workbook not found");
                throw openEx;
            }
        }
