    private int i = 0;
    
    private void StatusBarFade(string ispis) {
      i = 0;
      statusBar1AS2.Content = ispis;
      timerColor.Interval = 100;
      timerColor.AutoReset = true;
      timerColor.Elapsed += TimerColorOnElapsed;
      timerColor.Start();
    }
    
    private void TimerColorOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs) {
      Dispatcher.BeginInvoke(
        (new Action(
          () => {
            ++i;
            statusBar1AS2.Foreground = i % 2 == 0 || i > 15 ? Brushes.Black : Brushes.Gold;
            if (i < 30)
              return;
            timerColor.Stop();
            timerColor.Elapsed -= TimerColorOnElapsed;
            statusBar1AS2.Content = string.Empty;
          })));
    }
