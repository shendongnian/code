            String sHeet = "Pivot";
          
            DataTable excelTable = new DataTable();
            excelTable.Clear();
            string excelFile = "C:\\test_pivot.xlsx";
            Excel.Application excel = new Excel.Application();
            Excel.Workbook wb = excel.Workbooks.Open(excelFile);
            Excel.Worksheet pivotWorkSheet = (Excel.Worksheet)wb.Sheets[sHeet];
            Excel.Range xlRange = pivotWorkSheet.UsedRange;
            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;
            string[] lColumns = new string[2] { "Column1","Column2" };
            if (excelTable.Columns.Count <= 0)
            {
                foreach (string column in lColumns)
                {
                    excelTable.Columns.Add(column);
                }
            }
            Object[] exrow = new object[colCount];
            for (int row=1; row <= rowCount; row++)
            {
                for (int j = 1; j <= colCount; j++)
                {  
                    exrow[j - 1] = xlRange.Cells[row, j].Text;
                    Console.WriteLine(xlRange.Cells[row, j].Text);
                }
                excelTable.Rows.Add(exrow);
                //excelTable.Rows.Add(exrow);
            }
            String str = excelTable.ToString();
        }
