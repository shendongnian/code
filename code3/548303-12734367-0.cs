    private DispatcherTimer hitTestTimer = new DispatcherTimer();
    private int timerCount = 5;
    public MyConstructor() {
      hitTestTimer.Tick += OnHitTestTimerTick;
      hitTestTimer.Interval = new TimeSpan(0, 0, 1);
    }
    private void OnHitTestTimerTick(object sender, EventArgs e)
    {
      if (timerCount > 1)
      {
        timerCount--;
      }
      else
      {
        // CLICK!
      }
    }
