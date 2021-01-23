            HSSFWorkbook wb;
            NPOI.SS.UserModel.ISheet sh;
            string Sheet_name;
            using (var fs = new FileStream(excel_file_Path, FileMode.Open, FileAccess.Read))
            {
                wb = new HSSFWorkbook(fs);
                Sheet_name = wb.GetSheetAt(0).SheetName;  //get first sheet name
            }
            DataTable DT = new DataTable();
            DT.Rows.Clear();
            DT.Columns.Clear();
            // get sheet
            sh = wb.GetSheet(Sheet_name);
            // add neccessary columns
            if (DT.Columns.Count < sh.GetRow(0).Cells.Count)
            {
                for (int j = 0; j < sh.GetRow(0).Cells.Count; j++)
                {
                    DT.Columns.Add(Convert.ToString(sh.GetRow(0).Cells[j]), typeof(string));
                }
            }
            // add row
            DT.Rows.Add();
            int i = 1;
            while (sh.GetRow(i) != null)
            {
                // write row value
                for (int j = 0; j < sh.GetRow(i).Cells.Count; j++)
                {
                    var cell = sh.GetRow(i).GetCell(j);
                    if (cell != null)
                    {
                        // TODO: you can add more cell types capatibility, e. g. formula
                        switch (cell.CellType)
                        {
                            case CellType.Numeric:
                                DT.Rows[i][j] = sh.GetRow(i).GetCell(j).NumericCellValue;
                                //dataGridView1[j, i].Value = sh.GetRow(i).GetCell(j).NumericCellValue;
                                break;
                            case CellType.String:
                                DT.Rows[i-1][j] = sh.GetRow(i).GetCell(j).StringCellValue;
                                break;
                        }
                    }
                }
                i++;
            }
            return DT;
        }
