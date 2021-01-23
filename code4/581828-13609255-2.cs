                //place source file within your current:
                //project directory\bin\debug and you should find extracted file next to the source file 
                var pathtoRead = Path.Combine(Environment.CurrentDirectory, "tst.xlsx");
                var pathtoWrite = Path.Combine(Environment.CurrentDirectory, "tst.txt");
                
                Net.SourceForge.Koogra.IWorkbook genericWB = Net.SourceForge.Koogra.WorkbookFactory.GetExcel2007Reader(pathtoRead);
                Net.SourceForge.Koogra.IWorksheet genericWS = genericWB.Worksheets.GetWorksheetByIndex(0);
                StringBuilder SbXls = new StringBuilder();
                for (uint r = genericWS.FirstRow; r <= genericWS.LastRow; ++r)
                {
                    Net.SourceForge.Koogra.IRow row = genericWS.Rows.GetRow(r);
                    string LineEnding = string.Empty;
                    for (uint ColCount = genericWS.FirstCol; ColCount <= genericWS.LastCol; ++ColCount)
                    {
                        var formated = row.GetCell(ColCount).GetFormattedValue();
                        if (ColCount == 1)
                            LineEnding = Environment.NewLine;
                        else if (ColCount == 0)
                            LineEnding = "\t";
                        if (ColCount > 1 == false)
                            SbXls.Append(string.Concat(formated, LineEnding));
                    }
                }
                File.WriteAllText(pathtoWrite, SbXls.ToString());
