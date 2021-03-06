    AutoResetEvent done = new AutoResetEvent(true);
    ...
    for(int i = 0; i<mySimulation.Count(); i++)
    {
        // Is somebody working?
        // If so I wait...
        done.WaitOne();
        if (i==0)
        {
            ....
            myReverseGeocodeQuery_1.QueryCompleted += ReverseGeocodeQuery_QueryCompleted_1;
            done.Reset(); // Hey I'm working, wait!
            myReverseGeocodeQuery_1.QueryAsync();
        }
        ...
    }
    ...
    void ReverseGeocodeQuery_QueryCompleted_1(...)
    {
        ...
        done.Set(); // I'm done! Your turn...
    }
