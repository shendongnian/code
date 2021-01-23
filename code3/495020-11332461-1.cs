    using (ExcelPackage xlPackage = new ExcelPackage(newFile))
                {
                    foreach (ExcelWorksheet worksheet in xlPackage.Workbook.Worksheets)
                    {
                        var dimension = worksheet.Dimension;
                        if (dimension == null) { continue; }
                        var cells = from row in Enumerable.Range(dimension.Start.Row, dimension.End.Row)
                                    from column in Enumerable.Range(dimension.Start.Column, dimension.End.Column)
                                    //where worksheet.Cells[row, column].Value.ToString() != String.Empty
                                    select worksheet.Cells[row, column];
                        try
                        {
                            foreach (var excelCell in cells)
                            {
                                try
                                {
                                    if (excelCell.Value.ToString().Equals("[Customer]")) { excelCell.Value = "Customer Name"; }
                                }
                                catch (Exception) { }
                            }
                        }
                        catch (Exception a) { Console.WriteLine(a.Message); }
                    }
