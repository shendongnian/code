    var interval = new TimeSpan(0, 0, 1);
    var nextTick = DateTime.Now + interval;
    while (true)
    {
        while (DateTime.Now > nextTick)
        {
            Thread.Sleep(nextTick - DateTime.Now);
        }
        nextTick = DateTime.Now + interval; // Notice we're adding onto .Now instead of when the last tick was supposed to be. This is where slew comes from
        // Insert tick() code here
    }
