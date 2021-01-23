     Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"\\xxxx\yyyy.xlsx");
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;
            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;
            string Kund = "";
            for (int i = 1; i <= rowCount; i++)
            {
                for (int j = 1; j <= colCount; j++)
                {
                    if ((j == 1) && (i > 1))
                    {
                        MySqlConnection conn = new MySqlConnection(databas);
                        Kund = xlRange.Cells[i, j].Value2.ToString();
                    }
                    ...
                }
                    ...
             }
               xlApp.Workbooks.Close();
