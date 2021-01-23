    FileInfo existingFile = new FileInfo(filePath);
    
                using (var package = new ExcelPackage(existingFile))
                {
                    ExcelWorkbook workBook = package.Workbook;
                    
                    if (workBook != null)
                    {
                        if (workBook.Worksheets.Count > 0)
                        {
                            int i = 0;
                            foreach(ExcelWorksheet worksheet in workBook.Worksheets)
                            {
                                xlWorkSeet1[i] = worksheet;
                                i = i + 1;
                            }
                     
                        }
                    }
