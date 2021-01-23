      Process[] myProcess = Process.GetProcessesByName("AcroRd32");
      for (int i = 0; i < procesoProg.Length; i++)
      {
        if (myProcess[i].MainWindowTitle.Contains("MyTitle"))
        {
          myProcess[i].CloseMainWindow();
          Thread.Sleep(300);
        }
      }
