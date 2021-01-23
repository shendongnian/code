    int i = 0;
    var timers = new List<System.Threading.Timer>();
    foreach (KeyValuePair<string, object> record in Dict)
    {
        var _recordStored = record; //THIS IS(was) SUPPOSED TO FIX MY WOES!!!
        timers.Add(new System.Threading.Timer(_ => {
           ... rest of your timer code here
        }, null, TimeSpan.Zero, new TimeSpan(0, 0,0,0,1))); // extra end parenthesis here
    }
    for (; ; )
    {
        System.Threading.Thread.Sleep(10000);
    }
    GC.KeepAlive(timers); // prevent the list from being collected which would ...
                          // end up making the timers eligible for collection (again)
