    using OfficeOpenXml;
     using (var excelPackage = new ExcelPackage(fi))
            {
                ExcelWorkbook workbook = excelPackage.Workbook;
                if (workbook != null)
                {
                    if (workbook.Worksheets.Count > 0)
                    {
                        ExcelWorksheet worksheet = workbook.Worksheets.Single(a => a.Name == sheetname);
                        for (int i = row; i < worksheet.Dimension.End.Row; i++)
                        {
                            if (worksheet.Cells[i, column].Value != null)
                            {
                                try
                                {
                                    double s = double.Parse(worksheet.Cells[i, column].Value.ToString());
                                    lista.Add(s);
                                }
                                catch (FormatException)
                                {
                                    
                                }
                                
                                
                            }
                        }
                    }
                }
            }
