    ManualResetEvent run = new ManualResetEvent(true);
    
    void ResumeButton_Click(object sender, ButtonClickEventArgs e)
    {
      run.Set();
      PauseButton.Enabled = true;
      ResumeButton.Enabled = false;
    }
    
    void PauseButton_Click(object sender, ButtonClickEventArgs e)
    {
      run.Reset();
      PauseButton.Enabled = false;
      ResumeButton.Enabled = true;
    }
    
    void MyTask(void)
    {
        while (run.WaitOne())  // Wait for the run signal.
        {
          // Do work here.
        }
    }
