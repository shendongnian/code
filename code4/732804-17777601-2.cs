    System.Diagnostics.Process[] process=System.Diagnostics.Process.GetProcessesByName("Excel");
    foreach (System.Diagnostics.Process p in process)
    {
        if (!string.IsNullOrEmpty(p.ProcessName))
        {
            try
            {
                p.Kill();
            }
            catch { }
        }
    }
