    long beginValue = NetworkInterface.GetIPv4Statistics().BytesReceived;
    DateTime beginTime = DateTime.Now;
    // do something
    long endValue = NetworkInterface.GetIPv4Statistics().BytesReceived;
    DateTime endTime = DateTime.Now;
    long recievedBytes = endValue - beginValue;
    double totalSeconds = (endTime - beginTime).TotalSeconds;
    
    var bytesPerSecond = recievedBytes / totalSeconds;
