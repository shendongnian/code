    var interval = new TimeSpan(0, 0, 1);
    var nextTick = DateTime.Now + interval;
    while (true)
    {
        while (DateTime.Now > nextTick)
        {
            Thread.Sleep(nextTick - DateTime.Now);
        }
        nextTick += interval; // Notice we're adding onto when the last tick was supposed to be, not when it is now
        // Insert tick() code here
    }
