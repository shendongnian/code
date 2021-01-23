    private static object _padLock = new object();
    void SomeTask(object o)
    {
        // lock around disabling the timer
        lock(_padLock)
        {
            // return if some other thread beat us to it.
            if (!_timer.Enabled) return;
            _timer.Enabled = false;
        }
        try{
        // ...  work...
        }finally{
            _timer.Enabled = true;
        }
    }
