    public static class WatchDog
    {
        static object locker = new object();
        static long lastPacketReceived;
        static Stopwatch stopWatch = new Stopwatch();
        static long threshold = 5000;
        static WatchDog()
        {
            Timer watchDogTimer = new Timer(1000);
            watchDogTimer.Elapsed += new ElapsedEventHandler(watchDogTimer_Elapsed);
            watchDogTimer.Start();
            stopWatch.Start();
        }
    
        static void watchDogTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            lock (locker)
            {
                if ((stopWatch.ElapsedMilliseconds - lastPacketReceived) > threshold)
                {
                    // threshold exceeded
                }
            }
        }
    
        public static void PacketReceived()
        {
            lock (locker)
            {
                lastPacketReceived = stopWatch.ElapsedMilliseconds;
            }
        }
    }
