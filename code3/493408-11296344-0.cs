    DateTime target = ...
    int interval = (int)(target - DateTime.Now).TotalMilliseconds;
    var timer = new System.Timers.Timer(interval);
    timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
    timer.Enabled = true;
