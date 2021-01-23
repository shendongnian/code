    using Aspose.Cells;
    using System;
    
    namespace ExcelReader
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Replace path for your file
                readXLS(@"C:\MyExcelFile.xls"); // or "*.xlsx"
                Console.ReadKey();
            }
    
            public static void readXLS(string PathToMyExcel)
            {
                //Open your template file.
                Workbook wb = new Workbook(PathToMyExcel);
    
                //Get the first worksheet.
                Worksheet worksheet = wb.Worksheets[0];
    
                //Get cells
                Cells cells = worksheet.Cells;
    
                // Get row and column count
                int rowCount = cells.MaxDataRow;
                int columnCount = cells.MaxDataColumn;
    
                // Current cell value
                string strCell = "";
    
                Console.WriteLine(String.Format("rowCount={0}, columnCount={1}", rowCount, columnCount));
    
                for (int row = 0; row <= rowCount; row++) // Numeration starts from 0 to MaxDataRow
                {
                    for (int column = 0; column <= columnCount; column++)  // Numeration starts from 0 to MaxDataColumn
                    {
                        strCell = "";
                        strCell = Convert.ToString(cells[row, column].Value);
                        if (String.IsNullOrEmpty(strCell))
                        {
                            continue;
                        }
                        else
                        {
                            // Do your staff here
                            Console.WriteLine(strCell);
                        }
                    }
                }
            }
        }
    }
