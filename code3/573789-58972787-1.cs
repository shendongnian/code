    public static DataSet ReadExcelFileToDataSet2(string filePath, bool isFirstRowHeader=true)
        {
            DataSet result = new DataSet();
            Excel.ExcelPackage xlsPackage = new Excel.ExcelPackage(new FileInfo(filePath));  //using Excel = OfficeOpenXml;    <--EPPLUS
            Excel.ExcelWorkbook workBook = xlsPackage.Workbook;
            try
            {
                for (int count = 1; count <= workBook.Worksheets.Count; count++)
                {
                    Excel.ExcelWorksheet wsworkSheet = workBook.Worksheets[count];
                    if (wsworkSheet.Name.ToLower() == "sheetName")
                    {
                        wsworkSheet.Column(4).Style.Numberformat.Format = "MM-dd-yyyy";  // set column value to read as Date Type or numberformat
                    }
                    DataTable tbl = new DataTable();
                    // wsworkSheet.Dimension - (It will return cell dimesion like A1:N7 , means returning the worksheet dimesions.)
                    // wsworkSheet.Dimension.End.Address - (It will return right bottom cell like N7)
                    // wsworkSheet.Dimension.End.Columns - (It will return count from A1 to N7  like here 14)
                    foreach (var firstRowCell in wsworkSheet.Cells[1, 1, 1, wsworkSheet.Dimension.End.Column])  //.Cells[Row start, Column Start, Row end, Column End]
                    {
                       var colName = "";
                       colName = firstRowCell.Text;
                       tbl.Columns.Add(isFirstRowHeader ? colName : string.Format("Column {0}", firstRowCell.Start.Column));  //Geth the Column index (index starting with 1) from the left top.
                    }
                    var startRow = isFirstRowHeader ? 2 : 1;
                    for (int rowNum = startRow; rowNum <= wsworkSheet.Dimension.End.Row; rowNum++)
                    {
                        var wsRow = wsworkSheet.Cells[rowNum, 1, rowNum, wsworkSheet.Dimension.End.Column]; //  wsworkSheet.Cells[Row start, Column Start, Row end, Column End]
                        DataRow row = tbl.Rows.Add();
                        foreach (var cell in wsRow)
                        {
                            row[cell.Start.Column - 1] = cell.Text;
                        }
                    }
                    tbl.TableName = wsworkSheet.Name;
                    result.Tables.Add(tbl);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }
