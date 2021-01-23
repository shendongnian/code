    public void StartProcess()
    {
          var process = new Process();
          process.EnableRaisingEvents = true;
          process.Exited += new EventHandler(process_Exited);
          process.Start();
    }
