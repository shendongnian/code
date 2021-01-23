      public Byte[] ExportToExcel(string title, string author, DateTime date)
        {
            ExcelPackage package = new ExcelPackage();
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(title);
    if (_Columns != null)
                {
    
                    Dictionary<int, Func<object, string>> internalMappingGetter = new Dictionary<int, Func<object, string>>();
    
                    //create the Header of the body
                    foreach (ColumnExcel entity in _Columns)
                    {
                        worksheet.Cells[RowIndex, ColumnIndex].Value = entity.HeaderName;
                        worksheet.Cells[RowIndex, ColumnIndex].Style.WrapText = true;
                        BorderCell(worksheet.Cells[RowIndex, ColumnIndex]);
                        worksheet.Column(ColumnIndex).Width = entity.Width;
                        ColumnIndex++;
                    }
    
                    RowIndex++;
    
                    if (_DataSource != null)
                    {
                        foreach (Object o in _DataSource)
                        {
                            ColumnIndex = 1;
                            foreach (ColumnExcel column in _Columns)
                            {
                                column.Apply(worksheet.Cells[RowIndex, ColumnIndex], o);
                                worksheet.Column(ColumnIndex).BestFit = true;
                                worksheet.Cells[RowIndex, ColumnIndex].Style.WrapText = true;
                                //BorderCell(worksheet.Cells[RowIndex, ColumnIndex]);
                                ColumnIndex++;
                            }
                            RowIndex++;
                        }
                    }
