                var applicationClass = new Application();
                var workbook = applicationClass.Workbooks.Open(workbookPath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing
                                    , Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                var worksheet = workbook.GetWorksheet(sheet);
                var usedRange = worksheet.UsedRange;
    
                for (int i = beginIndexRow; i < usedRange.Rows.Count; i++) 
                {
                    var input = (Range)usedRange.Cells[i, 1]; //I read the first column
                    
                }
                workbook.Close(false, workbookPath, null);
                applicationClass.Quit();
                while (Marshal.ReleaseComObject(usedRange) > 0)
                { }
                while (Marshal.ReleaseComObject(worksheet) > 0)
                { }
                while (Marshal.ReleaseComObject(workbook) > 0)
                { }
                while (Marshal.ReleaseComObject(applicationClass) > 0)
                { }
