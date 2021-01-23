    System.Diagnostics.Process[] Client =  
                System.Diagnostics.Process.GetProcessesByName("Client");
     ProcessMemoryReader preader = new ProcessMemoryReader();
     if (Client != null && Client.Length > 0) {
         preader.ReadProcess = Client[0];
         preader.OpenProcess();
     }
     else {
         // Error handling...
     }
