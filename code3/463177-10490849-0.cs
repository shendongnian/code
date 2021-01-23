    public static void Move(int xDelta, int yDelta, int timeInMilliseconds)
    {
        var xRate = timeInMilliseconds / xDelta + 1;
        var yRate = timeInMilliseconds / yDelta + 1;
        var xThread = new Thread(() =>
                                     {
                                         for (var i = 0; i < xDelta; i++)
                                         {
                                             Move(1, 0);
                                             Thread.Sleep(xRate);
                                         }
                                     });
     
        var yThread = new Thread(() =>
                                     {
                                         for (var i = 0; i < yDelta; i++)
                                         {
                                             Move(0, 1);
                                             Thread.Sleep(yRate);
                                         }
                                     });
        xThread.Start();
        yThread.Start();
        xThread.Join();
        yThread.Join();
    }
