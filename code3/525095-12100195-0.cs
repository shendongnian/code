    for (int i = 0; ; i--)
    {
         foreach (Process clsProcess in Process.GetProcesses())
         {
              if (clsProcess.ProcessName.Contains("notepad"))
              {
                   Console.WriteLine("True");
              }
              else {
                   Console.WriteLine("NFalse");
              }
         }
         Thread.Sleep(10000);
    }
