    Timer myTimer = new Timer();
    myTimer.Interval = 500;
    myTimer.Tick = OnTimerTick;
    
    private void OnTimerTick(object o, EventArgs e)
    {
      myTimer.Stop();
      DataGridView1[2, pos].Value = txtText.Text;
    }
    
    private void txtText_TextChanged(object sender, EventArgs e)
    {
       if(!myTimer.Enabled) myTimer.Start();
    }
