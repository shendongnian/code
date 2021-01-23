            //Create an Excel App
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook xlWorkBook = null;
            Microsoft.Office.Interop.Excel._Worksheet xlWorksheet;
            
            //Open a Workbook
            xlWorkBook = xlApp.Workbooks.Open(@"d:\test.xlsx");
            xlWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Sheets[1];
            //My Workbook contains 10 rows with some data and formatting
            //I Hide rows 3, 4 & 5
            Microsoft.Office.Interop.Excel.Range hiddenRange = xlWorksheet.get_Range("A3:C5");
            hiddenRange.EntireRow.Hidden = true;
            //Get the entire sheet and Clear everything on it including data & formatting
            Microsoft.Office.Interop.Excel.Range allRange = xlWorksheet.UsedRange;
            allRange.Clear();
            //Now Add some new data, say a Title on the first cell, and some more data in a loop later
            xlWorksheet.Cells[1, 1] = "Title";
            for (int i = 6; i < 10; i++)
            {
                xlWorksheet.Cells[i, 1] = i.ToString();
            }
            xlApp.Visible = true;
