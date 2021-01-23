            Net.SourceForge.Koogra.IWorkbook genericWB = Net.SourceForge.Koogra.WorkbookFactory.GetExcel2007Reader("tst.xlsx");
            //genericWB = Net.SourceForge.Koogra.WorkbookFactory.GetExcelBIFFReader("some.xls");
            Net.SourceForge.Koogra.IWorksheet genericWS = genericWB.Worksheets.GetWorksheetByIndex(0);
            for (uint r = genericWS.FirstRow; r <= genericWS.LastRow; ++r)
            {
                Net.SourceForge.Koogra.IRow row = genericWS.Rows.GetRow(r);
                for (uint c = genericWS.FirstCol; c <= genericWS.LastCol; ++c)
                {
                    // raw value
                    Console.WriteLine(row.GetCell(c).Value);
                    // formatted value
                    Console.WriteLine(row.GetCell(c).GetFormattedValue());
                }
            }
