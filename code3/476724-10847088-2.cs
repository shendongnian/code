    public class ColumnsExcel : IEnumerable
        {
            List<ColumnExcel> _Columns;
    
            public ColumnsExcel()
            {
                _Columns = new List<ColumnExcel>();
            }
       
    
            public void AddInt(Func<object,int> getValue, string headerName, int width, string format)
            {
                ColumnExcel entity = new ColumnExcelInt(headerName, width, format, getValue);
                _Columns.Add(entity);
            }
    
            public void AddString(Func<object, string> getValue, string headerName, int width )
            {
                ColumnExcel entity = new ColumnExcelstring(headerName, width, getValue);
                _Columns.Add(entity);
            }
    
            public void AddDateTime(Func<object, DateTime?> getValue, string headerName, int width, string format)
            {
                ColumnExcel entity = new ColumnExcelDateTime(headerName, width, format, getValue);
                _Columns.Add(entity);
            }
    
            public void AddDecimal(Func<object, decimal> getValue, string headerName, int width, string format)
            {
                ColumnExcel entity = new ColumnExcelDecimal(headerName, width, format, getValue);
                _Columns.Add(entity);
            }
    
            public IEnumerator GetEnumerator()
            {
                return _Columns.GetEnumerator();
            }
        }
