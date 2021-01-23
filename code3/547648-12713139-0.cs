    DispatcherTimer timer = new DispatcherTimer();
         				
    timer.Tick += delegate(object s, EventArgs args)
        			{
        				timer.Stop();
        				// do your work here
        			};
        
    // 300 ms timer
    timer.Interval = new TimeSpan(0, 0, 0, 0, 300); 
    timer.Start();
