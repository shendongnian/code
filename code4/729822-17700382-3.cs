    private void ManageXLSProcesses()
    {
            Process[] processes = System.Diagnostics.Process.GetProcessesByName("Excel");
            foreach (Process p in processes)
                p.Kill();
    }
