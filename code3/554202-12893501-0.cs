         private Process proc;
         private List<int> pids = new List<int>();
         public void StartProc()
         {
             // this tries to simulate what you're doing. Starts the process, then 
             // wait to be sure that the second process starts, then kill proc
             proc.Start();
             pids.Add(proc.Id);
             Thread.Sleep(300);
             try
             {
                 proc.Kill();
             }
             catch {}
         }
         // the method returns the PID of the process
         public int Test()
         {
             proc = new Process();
             proc.StartInfo.FileName = @"notepad.exe";
             for (int i = 0; i < 2; i++)
             {
                 Thread t = new Thread(StartProc);
                 t.Start();
                 Thread.Sleep(200);
             }
             Thread.Sleep(500);
             return proc.Id;
         }
