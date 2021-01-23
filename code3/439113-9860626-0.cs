    class Program
        {
            static void Main(string[] args)
            {
                string file = AppDomain.CurrentDomain.BaseDirectory + "SetArrayToExcel.xlsx";
                Excel.Application excelApp = new Excel.Application();
                excelApp.Visible = true;
                Excel.Workbook wb = excelApp.Workbooks.Open(file, Type.Missing, Type.Missing
                    , Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing
                    , Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing
                    , Type.Missing, Type.Missing);
                object[,] testTable = new object[2, 2]{{"6-Feb-10", 0.1}, {"26-Mar-10", 1.2}};
                Excel.Worksheet ws = wb.ActiveSheet as Excel.Worksheet;
                Excel.Range rng = ws.get_Range("rngSetValue", Type.Missing);
     
     
                //rng.Value2 = testTable;
                rng.set_Value(Type.Missing, testTable);
            }
        }
