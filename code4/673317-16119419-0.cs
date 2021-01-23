    private void timer_Tick(object sender, EventArgs e) 
    {
           Stopwatch stopWatch = Stopwatch.StartNew();
    
           // Your logics goes Here
           
           stopWatch.Stop();
           DateTime time = new DateTime(stopWatch.ElapsedTicks);
           labelTimer.Text = time.ToString("HH:mm:ss");
    }
