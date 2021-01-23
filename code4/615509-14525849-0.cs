    private DispatcherTimer _timer;
    
    private void StartFlash()
    {
      _timer = new DispatcherTimer();
      _timer.Interval = new TimeSpan(0,0,1);
      _timer.Tick += (s,e) => ChangeColour;
    }
    
    private void StopFlash()
    {
      _timer = null;
    }
    
    private void ChangeColour() {
      // Your colour changing logic goes here
      ContentPanel.Background = new SolidColorBrush(Color.FromArgb(a,r,g,b));
    }
