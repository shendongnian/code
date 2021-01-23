        public static DataSet GetDataSetFromXls(string excelFilePath)
        {
            IWorkbook workbook;
            using (FileStream stream = new FileStream(excelFilePath, FileMode.Open, FileAccess.Read))
            {
                workbook = new HSSFWorkbook(stream);  //2003 xls
                //workbook = new XSSFWorkbook();  //2007 xlsx
            }
            
            DataSet ds = new DataSet();
            for (int i = 0; i < workbook.NumberOfSheets; i++)
            {
                ISheet sheet = workbook.GetSheetAt(i); // zero-based index of your target sheet
                DataTable dt = new DataTable(sheet.SheetName);
                // write header row
                IRow headerRow = sheet.GetRow(0);
                foreach (ICell headerCell in headerRow)
                {
                    dt.Columns.Add(headerCell.ToString());
                }
                // write the rest
                int rowIndex = 0;
                foreach (IRow row in sheet)
                {
                    // skip header row
                    if (rowIndex++ == 0) continue;
                    DataRow dataRow = dt.NewRow();
                    dataRow.ItemArray = row.Cells.Select(c => c.ToString()).ToArray();
                    dt.Rows.Add(dataRow);
                }
                ds.Tables.Add(dt);
            }
            return ds;
        }
        public static void SaveDataSetToXls(DataSet ds, string savedExcelFilePath)
        {
            //IWorkbook workbook = new XSSFWorkbook();
            IWorkbook workbook = new HSSFWorkbook();
            
            foreach (DataTable dt in ds.Tables)
            {
                ISheet sheet = workbook.CreateSheet(dt.TableName);
                var row0 = sheet.CreateRow(0);//header
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    row0.CreateCell(j).SetCellValue(dt.Columns[j].ColumnName);
                }
                for (int i = 0; i < dt.Rows.Count; i++)//rest
                {
                    var row = sheet.CreateRow(1+i);
                    for (int j = 0; j < dt.Columns.Count; j++)
                        row.CreateCell(j).SetCellValue(dt.Rows[i][j].ToString());
                }
            }
            FileStream sw = File.Create(savedExcelFilePath);
            workbook.Write(sw);
            sw.Close();
        }
