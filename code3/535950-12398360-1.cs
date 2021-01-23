    private bool _IsShuttingDown = false;
        
    private void ChangeTime()
    {
       while (!_IsShuttingDown)
       {
          if (lbl1.InvokeRequired)
          {
             SetTimeDelegate setTime = new SetTimeDelegate(UpdateTimeLabel);
             lbl1.Invoke(setTime);
             Thread.Sleep(1000);
          }
          else
          {
             UpdateTimeLabel();
             Thread.Sleep(1000);
          }
       }
    }
    private void UpdateTimeLabel()
    {
       lbl1.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
    }
    protected override void OnClosing(CancelEventArgs e)
    {
       _IsShuttingDown = true;
       base.OnClosing(e);
    }
