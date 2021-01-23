    static void BeepWhen1530()
    {
      var alarmTime = new TimeSpan(15, 30, 00);
      while (true)
      {
        var clock = DateTime.Now.TimeOfDay;
        if (clock >= alarmTime && clock < alarmTime + TimeSpan.FromMinutes(1.0))
        {
          Console.WriteLine("Alarm: BEEP!");
          Console.Beep();
          // wait for two minutes so the alarm won't go off again until tomorrow
          Thread.Sleep(TimeSpan.FromMinutes(2.0));
        }
        
        // wait some time so we won't consume too much cpu cycles
        Thread.Sleep(TimeSpan.FromMilliseconds(500.0));
      }
    }
