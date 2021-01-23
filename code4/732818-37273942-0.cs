    var _excel = new Application();
    foreach (Workbook _workbook in _excel.Workbooks) {
        _workbook.Close(0);
    }
    
    _excel.Quit();
    _excel = null;
    var process = System.Diagnostics.Process.GetProcessesByName("Excel");
    foreach (var p in process) {
        if (!string.IsNullOrEmpty(p.ProcessName)) {
            try {
                p.Kill();
            } catch { }
        }
    }
