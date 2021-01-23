        public static void ExportDataTableToExcel(DataTable sourceTable, string fileName)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            MemoryStream memoryStream = new MemoryStream();
            HSSFSheet sheet = workbook.CreateSheet("Sheet1") as HSSFSheet;
            HSSFRow headerRow = sheet.CreateRow(0) as HSSFRow;
            sheet.SetColumnWidth(0, 7000);
            sheet.SetColumnWidth(1, 7000);
            sheet.SetColumnWidth(2, 7000);
            sheet.SetColumnWidth(3, 10000);
            sheet.SetColumnWidth(4, 7000);
            sheet.DefaultRowHeight = 3000;
            HSSFPalette palette = workbook.GetCustomPalette();
            palette.SetColorAtIndex(HSSFColor.BLUE.index, 41, 113, 153);
            palette.SetColorAtIndex(HSSFColor.GREEN.index, 129, 179, 78);
            palette.SetColorAtIndex(HSSFColor.CORAL.index, 235, 235, 235);
            palette.SetColorAtIndex(HSSFColor.LIGHT_BLUE.index, 233, 241, 245);
            IFont headerFont = workbook.CreateFont();
            headerFont.FontHeightInPoints = 16;
            headerFont.FontName = "Palatino Linotype";
            headerFont.Boldweight = 5;
            headerFont.Color = HSSFColor.WHITE.index;
            IFont font = workbook.CreateFont();
            font.FontHeightInPoints = 14;
            font.FontName = "Palatino Linotype";
            font.Boldweight = 5;
            font.Color = HSSFColor.BLUE.index;
            HSSFCellStyle headerStyle = (HSSFCellStyle)workbook.CreateCellStyle();
            headerStyle.FillForegroundColor = HSSFColor.GREEN.index; ;
            headerStyle.FillPattern = NPOI.SS.UserModel.FillPatternType.SOLID_FOREGROUND;
            headerStyle.BorderBottom = BorderStyle.THIN;
            headerStyle.BottomBorderColor = HSSFColor.WHITE.index;
            headerStyle.BorderRight = BorderStyle.THIN;
            headerStyle.RightBorderColor = HSSFColor.WHITE.index;
            headerStyle.BorderLeft = BorderStyle.THIN;
            headerStyle.LeftBorderColor = HSSFColor.WHITE.index;
            headerStyle.BorderTop = BorderStyle.THIN;
            headerStyle.TopBorderColor = HSSFColor.WHITE.index;
            headerStyle.VerticalAlignment = VerticalAlignment.CENTER;
            headerStyle.Alignment = HorizontalAlignment.CENTER;
            headerStyle.SetFont(headerFont);
            HSSFCellStyle oddStyle = (HSSFCellStyle)workbook.CreateCellStyle();
            oddStyle.FillForegroundColor = HSSFColor.CORAL.index;
            oddStyle.FillPattern = NPOI.SS.UserModel.FillPatternType.SOLID_FOREGROUND;
            oddStyle.BorderBottom = BorderStyle.THIN;
            oddStyle.BottomBorderColor = HSSFColor.WHITE.index;
            oddStyle.BorderRight = BorderStyle.THIN;
            oddStyle.RightBorderColor = HSSFColor.WHITE.index;
            oddStyle.BorderLeft = BorderStyle.THIN;
            oddStyle.LeftBorderColor = HSSFColor.WHITE.index;
            oddStyle.BorderTop = BorderStyle.THIN;
            oddStyle.TopBorderColor = HSSFColor.WHITE.index;
            oddStyle.VerticalAlignment = VerticalAlignment.CENTER;
            oddStyle.Alignment = HorizontalAlignment.CENTER;
            oddStyle.SetFont(font);
            HSSFCellStyle evenStyle = (HSSFCellStyle)workbook.CreateCellStyle();
            evenStyle.FillForegroundColor = HSSFColor.LIGHT_BLUE.index;
            evenStyle.FillPattern = NPOI.SS.UserModel.FillPatternType.SOLID_FOREGROUND;
            evenStyle.BorderBottom = BorderStyle.THIN;
            evenStyle.BottomBorderColor = HSSFColor.WHITE.index;
            evenStyle.BorderRight = BorderStyle.THIN;
            evenStyle.RightBorderColor = HSSFColor.WHITE.index;
            evenStyle.BorderLeft = BorderStyle.THIN;
            evenStyle.LeftBorderColor = HSSFColor.WHITE.index;
            evenStyle.BorderTop = BorderStyle.THIN;
            evenStyle.TopBorderColor = HSSFColor.WHITE.index;
            evenStyle.VerticalAlignment = VerticalAlignment.CENTER;
            evenStyle.Alignment = HorizontalAlignment.CENTER;
            evenStyle.SetFont(font);
            // handling header.
            foreach (DataColumn column in sourceTable.Columns)
            {
                var headercell = headerRow.CreateCell(column.Ordinal);
                headercell.SetCellValue(column.ColumnName);
                headercell.CellStyle = headerStyle;
                headerRow.Height = 600;
            }
            // handling value.
            int rowIndex = 1;
            foreach (DataRow row in sourceTable.Rows)
            {
                HSSFRow dataRow = sheet.CreateRow(rowIndex) as HSSFRow;
                dataRow.Height = 600;
                foreach (DataColumn column in sourceTable.Columns)
                {
                    var cell = dataRow.CreateCell(column.Ordinal);
                    cell.SetCellValue(row[column].ToString());
                    if (sourceTable.Rows.IndexOf(row) % 2 == 0)
                    {
                        cell.CellStyle = evenStyle;
                    }
                    else
                    {
                        cell.CellStyle = oddStyle;
                    }
                }
                rowIndex++;
            }
            workbook.Write(memoryStream);
            memoryStream.Flush();
            HttpResponse response = HttpContext.Current.Response;
            response.ContentType = "application/vnd.ms-excel";
            response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", fileName));
            response.Clear();
            response.BinaryWrite(memoryStream.GetBuffer());
            response.End();
        }
