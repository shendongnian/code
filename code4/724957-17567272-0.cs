     var procs = (from p in System.Diagnostics.Process.GetProcesses()
                         where p.ProcessName.StartsWith("s") // filter if needed. 
                         select new
                         {
                             Name = p.ProcessName,
                             Title = p.MainWindowTitle
                         }).Take(20).ToList(); ;
