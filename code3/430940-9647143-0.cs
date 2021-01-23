    bool hold = false;
    DispatcherTimer timer = new DispatcherTimer();
    private void x_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            hold = true;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 500);//days,hours,minutes,seconds,milliseconds
            timer.Tick += new EventHandler(timer_tick);
            timer.Start();
        }
    private void x_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            hold=false;
        }
    private void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            if(hold = true)
               {
               //et voilà, hold-event after 0,5 seconds
               // place actions that should be handled after 0,5seconds HERE
               }
         }
