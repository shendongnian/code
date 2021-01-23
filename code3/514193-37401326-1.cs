    private void timer_Tick(object sender, EventArgs e)
    {
      timer.Enabled = false;
      backgroundworker.RunWorkerAsync();
      timer.Enabled = true;
    }
