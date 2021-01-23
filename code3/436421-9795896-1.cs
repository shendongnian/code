    using Excel = Microsoft.Office.Interop.Excel;
    using Word = Microsoft.Office.Interop.Word;
    public class ExcelInteropTest
    {
        //private static Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
        public static void Parse(String filename)
        {
            var _app = new Excel.Application();
            var _workbooks = _app.Workbooks;
            _workbooks.OpenText(filename,
                                     DataType: Excel.XlTextParsingType.xlDelimited,
                                     TextQualifier: Excel.XlTextQualifier.xlTextQualifierNone,
                                     ConsecutiveDelimiter: true,
                                     Semicolon: true);
            Excel.Sheets sheets = _workbooks[1].Worksheets;
            Excel.Worksheet worksheet = (Excel.Worksheet)sheets.get_Item(1);
            List<String[]> excelData = new List<string[]>();
            for (int i = 1; i <= 6; i++)
            {
                Excel.Range range = worksheet.get_Range("A" + i.ToString(), "Z" + i.ToString());
                System.Array myvalues = (System.Array)range.Cells.Value;
                string[] strArray = myvalues.OfType<object>().Select(o => o.ToString()).ToArray();
                excelData.Add(strArray);
            }
            foreach (var item in excelData)
            {
                Console.WriteLine(String.Join("|",item));
            }
            
        }
    }
