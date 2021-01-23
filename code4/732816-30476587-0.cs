             wb.Close();
             app.Quit();
             System.Diagnostics.Process[] process = System.Diagnostics.Process.GetProcessesByName("Excel");
             foreach (System.Diagnostics.Process p in process)
             {
                 if (!string.IsNullOrEmpty(p.ProcessName) && p.StartTime.AddSeconds(+10) > DateTime.Now)
                 {
                     try
                     {
                         p.Kill();
                     }
                     catch { }
                 }
             }
