    System.Timers.Timer timer = new System.Timers.Timer(1000);
    timer.Elapsed += timer_Elapsed;
     private void timer_Elapsed(object sender, ElapsedEventArgs e)
     {
         counter++;
     }
    timer.Start();
    timer.Stop();
