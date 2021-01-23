    Stopwatch run_time = new Stopwatch();
    run_time.Start();
    
    Process.Start("bf3.exe");  //You will need to enter full path here
    
    
    while(true)
    {
                Process[] pListofProcess = Process.GetProcesses();
    
    
                bool bRunning = false;
    
                foreach (Process p in pListofProcess)
                {
                    string ProcessName = p.ProcessName;
    
                    ProcessName = ProcessName.ToLower();
    
                    if (ProcessName.CompareTo("bf3.exe") == 0)
                    {
                        bRunning = true;
                    }
    
                }
                if (bRunning == false)
                { 
                    run_time.Stop();
                    //Show elapsed time here.
                    break;
                    
                }
              Thread.Sleep(1000);
    }
