    for (int i = 0; ; i--)
    {
         Process[] processes = Process.GetProcessByName("notepad++"); // Without extension
         if(processes.Length > 0){
              Console.WriteLine("True");
         }
         else{
              Console.WriteLine("False");
         }
         Thread.Sleep(10000);
    }
