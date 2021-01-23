    Timer timer = new Timer();
    timer.Tick += new EventHandler(timer_Tick); // Everytime timer ticks, timer_Tick will be called
    timer.Interval = (1000) * (10);             // Timer will tick evert 10 seconds
    timer.Enabled = true;                       // Enable the timer
    timer.Start();             
