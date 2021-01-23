    private DispatcherTimer _dtTimer = null;
    public Constructor1(){
      _dtTimer = new DispatcherTimer();
      _dtTimer.Tick += new System.EventHandler(HandleTick);
      _dtTimer.Interval = new TimeSpan(0, 0, 0, 2); //Timespan of 2 seconds
      _dtTimer.Start();
    }
    
    private void HandleTick(object sender, System.EventArgs e) {
      _uiTextBlock.Text = "Timer ticked!";
    }
