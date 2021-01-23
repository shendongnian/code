    System.Timers.Timer timer = new System.Timers.Timer(45000); // timer will execute every 45 seconds
    timer.Elapsed += (sender, e) => {
        // your upload code here
    };
    timer.Start();
