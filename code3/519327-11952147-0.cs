    var timer = new System.Timers.Timer();
    timer.Interval = 5000; // every 5 seconds
    timer.Elapsed = (s, e) => {
        // Your code
    };
    timer.Start();
