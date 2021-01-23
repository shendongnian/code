    public Form1(string[] args)
    {
      endApplicationBackgroundWorker.DoWork += 
        new DoWorkEventHandler(endApplicationBackgroundWorker_DoWork);
      endApplicationBackgroundWorker.RunWorkerCompleted += 
        new RunWorkerCompletedEventHandler(endApplicationBackgroundWorker_RunWorkerCompleted);
      p.StartInfo.FileName = "notepad";
      endApplicationBackgroundWorker.RunWorkerAsync();
    }
    private void endApplicationBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
      p.Start();
      p.WaitForExit();
    }
    private void endApplicationBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      Form2 form2 = new Form2();
      System.Diagnostics.Process[] procs = System.Diagnostics.Process.GetProcessesByName(form1ProcessName);
      if (procs.Length != 0)
      {
        IntPtr hwnd = procs[0].MainWindowHandle;
        if (form2.ShowDialog(new WindowWrapper(hwnd)) == DialogResult.OK)
        {
          // process stuff
        }
      }
      this.Close();
      }
    }
