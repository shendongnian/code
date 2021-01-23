    xlApp = new Excel.ApplicationClass();
            int rCnt = 0;           
                {
                  
                var workbooks = xlApp.Workbooks;
                xlWorkBook = xlApp.Workbooks.Open(@"E:/try/" + DateTime.Now.ToString("M.d.yyyy")+@"/"+ projectName+ ".xlsx", 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", true, true, 0, true, 1, 0);
                var worksheets = xlWorkBook.Worksheets;
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets["Upload Data"];
                range = xlWorkSheet.UsedRange;
                var rows = range.Rows;
                totalt.Text = rows.Count.ToString();
                currentID.Text = (rows.Count + 1).ToString();               
    
                xlWorkBook.Close(true, null, null);
                xlApp.Quit();
    
                Marshal.ReleaseComObject(rows);
                Marshal.ReleaseComObject(range);
                Marshal.ReleaseComObject(xlWorkSheet);
                Marshal.ReleaseComObject(worksheets);
                Marshal.ReleaseComObject(xlWorkBook);
                Marshal.ReleaseComObject(workbooks);
                Marshal.ReleaseComObject(xlApp);
            }
    
        }
