    using System.Diagnostics;
    Process p1 = new Process();
    Process p2 = new Process();
    Process p3 = new Process();
    p1.StartInfo.FileName = "notepad.exe";
    p2.StartInfo.FileName = "notepad.exe";
    p3.StartInfo.FileName = "notepad.exe";
    //start the procs
    p1.Start();
    p2.Start();
    p3.Start();
    //kill the procs
    p1.Kill();
    p2.Kill();
    p3.Kill();
