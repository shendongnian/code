    int msLimit = 200;
    int nEntries = 500000;
    bool cancel = false;
    System.Timers.Timer t = new System.Timers.Timer();
    t.Interval = msLimit;
    t.Elapsed += (s, e) => cancel = true;
    t.Start();
    
    for (int i = 0; i < nEntries; i++)
    {
        // do sth
    	if (cancel) {
            break;
    	}
    }
