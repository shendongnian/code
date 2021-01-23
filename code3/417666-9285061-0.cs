    System.Diagnostics.ProcessStartInfo p = new System.Diagnostics.ProcessStartInfo(@"C:\OtherProgram.exe") ;
    p.Arguments="-RunForever";
    proc = new System.Diagnostics.Process();
    proc.StartInfo = p;
    proc.EnableRaisingEvents = true;
    proc.Exited += new EventHandler(myProcess_Exited);
    proc.Start();
