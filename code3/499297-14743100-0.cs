    HSSFWorkbook hssfworkbook = new HSSFWorkbook();
            foreach (DataTable dt in DataSource.Tables)
            {
                ISheet sheet1 = hssfworkbook.CreateSheet(dt.TableName);
                //Set column titles
                IRow headRow = sheet1.CreateRow(0); 
                for (int colNum = 0; colNum < dt.Columns.Count; colNum++)
                {
                    ICell cell = headRow.CreateCell(colNum);
                    cell.SetCellValue(dt.Columns[colNum].ColumnName);
                }
                //Set values in cells
                for (int rowNum = 1; rowNum <= dt.Rows.Count; rowNum++)
                {
                    IRow row = sheet1.CreateRow(rowNum);
                    for (int colNum = 0; colNum < dt.Columns.Count; colNum++)
                    {
                        ICell cell = row.CreateCell(colNum);
                        cell.SetCellValue(dt.Rows[rowNum - 1][colNum].ToString());
                    }
                }
                // Resize column width to show all data
                for (int colNum = 0; colNum < dt.Columns.Count; colNum++)
                {
                    sheet1.AutoSizeColumn(colNum);
                }
            }
