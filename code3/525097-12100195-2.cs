    for (int i = 0; ; i--)
    {
         Process[] processes = Process.GetProcessByName("notepad++.exe");
         if(processes.Length > 0){
              Console.WriteLine("True");
         }
         else{
              Console.WriteLine("NFalse");
         }
         Thread.Sleep(10000);
    }
