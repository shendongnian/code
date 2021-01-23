    public class ExcelApp : IExcelApp
    {
        private ApplicationClass _app;
        public ExcelApp()
        {
        }
        public IExcelWorkbook OpenWbk(string aPath)
        {
            return new ExcelWorkbook(_app.Workbooks.Open(aPath));
        }
    }
    public class ExcelWorkbook : IExcelWorkbook
    {
        private Workbook _wbk;
        public ExcelWorkbook(Workbook aWbk)
        {
            _wbk = aWbk;
        }
    }
