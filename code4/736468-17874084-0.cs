    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.Control)
      {
        splitpanel.AutoScroll = false;
      }
    }
    
    private void Form1_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.Control)
      {
        splitpanel.AutoScroll = true;
      }
    }
