    Process pr = new Process();
    ProcessStartInfo prs = new ProcessStartInfo();
    prs.FileName = @"notepad.exe";
    pr.StartInfo = prs;
    pr.EnableRaisingEvents = true;
    pr.Start();
    
    Thread.Sleep(2000);
    
    pr.CloseMainWindow();
    pr.Close();
                
    Console.WriteLine("press [enter] to exit");
    Console.ReadLine();
