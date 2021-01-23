    internal static bool Export2Excel(DataTable dataTable, bool Interactive) 
    {
        object misValue = System.Reflection.Missing.Value;
    
        // Note: don't include Microsoft.Office.Interop.Excel in reference (using),
        // it will cause ambiguity w/System.Data: both have DataTable obj
        Microsoft.Office.Interop.Excel.Application _appExcel = null;
        Microsoft.Office.Interop.Excel.Workbook _excelWorkbook = null;
        Microsoft.Office.Interop.Excel.Worksheet _excelWorksheet = null;
        try
        {
            // excel app object
            _appExcel = new Microsoft.Office.Interop.Excel.Application();
    
            // make it visible to User if Interactive flag is set
            _appExcel.Visible = Interactive;
    
            // excel workbook object added to app
            _excelWorkbook = _appExcel.Workbooks.Add(misValue);
    
            _excelWorksheet = _appExcel.ActiveWorkbook.ActiveSheet 
                as Microsoft.Office.Interop.Excel.Worksheet;
    
            // column names row (range obj)
            Microsoft.Office.Interop.Excel.Range _columnsNameRange;
            _columnsNameRange = _excelWorksheet.get_Range("A1", misValue);
            _columnsNameRange = _columnsNameRange.get_Resize(1, dataTable.Columns.Count);
    
            // data range obj
            Microsoft.Office.Interop.Excel.Range _dataRange;
            _dataRange = _excelWorksheet.get_Range("A2", misValue);
            _dataRange = _dataRange.get_Resize(dataTable.Rows.Count, dataTable.Columns.Count);
    
            // column names array to be assigned to columnNameRange
            string[] _arrColumnNames = new string[dataTable.Columns.Count];
    
            // 2d-array of data to be assigned to _dataRange
            string[,] _arrData = new string[dataTable.Rows.Count, dataTable.Columns.Count];
    
            // populate both arrays: _arrColumnNames and _arrData
            // note: 2d-array structured as row[idx=0], col[idx=1]
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                for (int j = 0; j < dataTable.Rows.Count; j++)
                {
                    _arrColumnNames[i] = dataTable.Columns[i].ColumnName;
                    _arrData[j, i] = dataTable.Rows[j][i].ToString();
                }
            }
    
            //assign column names array to _columnsNameRange obj
            _columnsNameRange.set_Value(misValue, _arrColumnNames);
    
            //assign data array to _dataRange obj
            _dataRange.set_Value(misValue, _arrData);
    
            // save and close if Interactive flag not set
            if (!Interactive)
            {
                // Excel 2010 - "14.0"
                // Excel 2007 - "12.0"
                string _ver = _appExcel.Version;
    
                string _fileName ="TableExport_" + 
                    DateTime.Today.ToString("yyyy_MM_dd") + "-" +
                    DateTime.Now.ToString("hh_mm_ss");
    
                // check version and select file extension
                if (_ver == "14.0" || _ver == "12.0")  { _fileName += ".xlsx";}
                else { _fileName += ".xls"; }
    
                // save and close Excel workbook
                _excelWorkbook.Close(true, "{DRIVE LETTER}:\\" + _fileName, misValue);
            }
            return true;
        }
        catch (Exception ex) {  throw; }
        finally
        {
            // quit excel app process
            if (_appExcel != null)
            {
                _appExcel.UserControl = false;
                _appExcel.Quit();
                _appExcel = null;
                misValue = null;
            }
        }
    }
