    System.Diagnostics.Process[] process=System.Diagnostics.Process.GetProcessesByName("Excel");
    foreach (System.Diagnostics.Process p in process)
    {
        if (!string.IsNullOrEmpty(ProName))
        {
            try
            {
                p.Kill();
            }
            catch { }
        }
    }
