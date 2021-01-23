    Process[] xlProc;
    public bool isExcelRunning()
        {
            try
            {
                xlProc = Process.GetProcessesByName("excel");
                if (xlProc.Length > 0)
                {
                    logEvents("A running instance of Excel has been detected. The installation is stopping.");
                    return true;
                }
            }
            catch { }
            return false;
        }
