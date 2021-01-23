    System.Diagnostics.ProcessStartInfo p = new 
         System.Diagnostics.ProcessStartInfo(@"vcredist_x86.exe") ;
    p.Arguments="-RunForever";
    proc = new System.Diagnostics.Process();
    proc.StartInfo = p;
    proc.EnableRaisingEvents = true;
    proc.Exited += new EventHandler(myProcess_Exited);
    proc.Start();
