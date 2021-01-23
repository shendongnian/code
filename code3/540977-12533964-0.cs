    using System;
    using System.Data;
    using System.Runtime.InteropServices;
    using Excel = Microsoft.Office.Interop.Excel;
    
    namespace ConsoleApplication3
    {
        class Program
        {
            static void Main()
            {
                Excel.Application application = new Excel.Application();
                Excel.Workbook workbook = application.Workbooks.Add();
                Excel.Worksheet worksheet = workbook.Sheets[1];
    
                DataTable dataTable = new DataTable();
                DataColumn column = new DataColumn("My Datacolumn");
    
                dataTable.Columns.Add(column);
                dataTable.Rows.Add(new object[] {"Foobar"});
    
                var columns = dataTable.Columns.Count;
                var rows = dataTable.Rows.Count;
    
                Excel.Range range = worksheet.Range["A1", String.Format("{0}{1}", GetExcelColumnName(columns), rows)];
    
                object[,] data = new object[rows,columns];
    
                for (int rowNumber = 0; rowNumber < rows; rowNumber++)
                {
                    for (int columnNumber = 0; columnNumber < columns; columnNumber++)
                    {
                        data[rowNumber, columnNumber] = dataTable.Rows[rowNumber][columnNumber].ToString();
                    }
                }
    
                range.Value = data;
    
                workbook.SaveAs(@"C:\test\whatever123.xlsx");
                workbook.Close();
    
                Marshal.ReleaseComObject(application);
            }
    
            private static string GetExcelColumnName(int columnNumber)
            {
                int dividend = columnNumber;
                string columnName = String.Empty;
                int modulo;
    
                while (dividend > 0)
                {
                    modulo = (dividend - 1) % 26;
                    columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                    dividend = (int)((dividend - modulo) / 26);
                }
    
                return columnName;
            }
        }
    }
