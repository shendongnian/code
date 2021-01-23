    private object _lockObj;
    private long bytesPerSecond = 0;
    private Timer _refreshTimer = new Timer { Interval = 1000 };
    
    // do in ctor or some init method
    _refreshTimer.Tick += _refreshTimer_Tick;
    _refreshTimer.Enabled = true;
    
    private void _refreshTimer_Tick(object sender, EventArgs e)
    {
      ThreadPool.QueueUserItem(callback => 
      {
        long beginValue = NetworkInterface.GetIPv4Statistics().BytesReceived;
        DateTime beginTime = DateTime.Now;
 
        Thread.Sleep(1000);
        long endValue = NetworkInterface.GetIPv4Statistics().BytesReceived;
        DateTime endTime = DateTime.Now;
        long recievedBytes = endValue - beginValue;
        double totalSeconds = (endTime - beginTime).TotalSeconds;
    
        lock(_lockObj)
        {
          bytesPerSecond = recievedBytes / totalSeconds;
        }
      });
    }
