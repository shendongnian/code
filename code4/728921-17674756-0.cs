    var procs = (from p in System.Diagnostics.Process.GetProcesses()
                         select new
                         {
                             Name = p.ProcessName,
                          
                             IsShareAllowed = Convert.ToBoolean(r.Next(-1, 1))
                         }).ToList(); ;
            list.ItemsSource = procs;
