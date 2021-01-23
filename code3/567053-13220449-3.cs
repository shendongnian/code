    Stopwatch stopwatch = new Stopwatch();
    TimeSpan timeGone;
    // Use TimeSpan constructor to specify:
    // ... Days, hours, minutes, seconds, milliseconds.
    // ... The TimeSpan returned has those values.
    TimeSpan RequiredTimeLine = new TimeSpan(0, 0, 0, 15, 0);//set to 15 sec
 
    While ( timeGone.Seconds < RequiredTimeLine.Seconds )
    {
        stopwatch.Start();
        Start();
        timeGone = stopwatch.Elapsed;
    }
    Stop();//your method which will stop listening
