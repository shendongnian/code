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
      form2.TopMost = true;
      form2.FormClosing += new FormClosingEventHandler(form2_FormClosing);    
      form2.Show(this);
    }
    private void form2_FormClosing(object sender, FormClosingEventArgs e)
    {
      this.BeginInvoke(new MethodInvoker(delegate { this.Close(); }));
    }
