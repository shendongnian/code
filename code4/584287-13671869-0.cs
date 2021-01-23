    System.Diagnostics.Process proc = new System.Diagnostics.Process();
    proc.StartInfo.FileName = "ping.exe";
    proc.StartInfo.Arguments = "8.8.8.8";
    
    proc.StartInfo.RedirectStandardOutput = true;
    proc.StartInfo.UseShellExecute = false;
    proc.StartInfo.CreateNoWindow = true;
    proc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden; 
    proc.Start();
    StreamReader q = proc.StandardOutput;
    
    
    Console.Write(q.ReadToEnd());
    Console.ReadKey();
