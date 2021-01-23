            Excel.Application oExcel = new Excel.Application();
            //oExcel.Visible = true; (this caused me huge problems
            Excel.Workbook oBook = oExcel.Workbooks.Open(@"C:\Yoink\Birr Castle Demesne     Interactive Map\Birr Castle Demesne Interactive Map\bin\Debug\Red Tree Trail.xlsx");
            Excel.Worksheet oSheet1 = oBook.Worksheets["Red Tree Trail"] as Excel.Worksheet; (use your own worksheet title there)
            Excel.Range rng = oSheet1.get_Range("A1", "AJ51"); (use your own range there
            int rowCount = rng.Rows.Count;
            int colCount = rng.Columns.Count;
            string[,] tsReqs = new string[rowCount, colCount];
            for (int i = 1; i <= rowCount; i++)
            {
                for (int j = 1; j <= colCount; j++)
                {
                    string str = rng.Cells[i, j].Text;
                    tsReqs[i - 1, j - 1] = str;
                }
            }
