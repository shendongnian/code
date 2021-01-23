       tmr.Interval = 500;
       System.Diagnostics.ProcessStartInfo proc = new System.Diagnostics.ProcessStartInfo();
       proc.FileName = @"C:\\Windows\\System32\\RunDll32.exe";
       proc.Arguments = "shell32.dll,Control_RunDLL inetcpl.cpl,Internet,4";
       System.Diagnostics.Process.Start(proc);
       tmr.Tick += new EventHandler(tmr_Tick);
       tmr.Start();
 
